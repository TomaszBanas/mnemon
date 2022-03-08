import { Object3D, Event, Ray, Vector3, BufferGeometry, Mesh, MeshBasicMaterial, BufferAttribute, DoubleSide } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { BoundingBox } from "../models/bounding-box";

export class GeometryElement implements IElement
{
    public key: string = generateUUID();
    public elementType: ElementType = ElementType.Geometry;
    public object?: Object3D<Event> | undefined;
    public selectionPriority: number = 0;
    public removeByKey: Function | undefined;
    public boundingBox?: BoundingBox | undefined;

    public constructor(
        public vertices: number[],
        public indexes: number[],
        public normals: number[],
        public colors: number[]
    )
    {
        const geometry = new BufferGeometry();
        geometry.setAttribute( 'position', new BufferAttribute( new Float32Array(vertices), 3 ) );
        // geometry.setAttribute( 'normal', new BufferAttribute( new Float32Array(normals), 3 ) );
        geometry.setAttribute( 'color', new BufferAttribute( new Float32Array(colors), 3 ) );
        geometry.setIndex(indexes);
        geometry.computeVertexNormals();
        // side: DoubleSide
        const material = new MeshBasicMaterial( { vertexColors: true } );
        this.object = new Mesh( geometry, material );
        geometry.computeBoundingBox();
        if(geometry.boundingBox)
            this.boundingBox = new BoundingBox(geometry.boundingBox);
    }

    public addElement(element: IElement): void { }
    public removeElement(element: IElement): void { }
    public getAllElement(): IElement[] {
        return [];
    }
    public getBoundingBox(): BoundingBox | undefined {
        return this.boundingBox;
    }
    public intersect(ray: Ray): Vector3 | undefined {
        const boxData = this.getBoundingBox();
        if(!boxData) return undefined;
        return boxData.intersect(ray);
    }
    public cloneElement(): IElement {
        return this;
    }
    public removeSelf(): void {
        
    }
    
}