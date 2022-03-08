import { Box3, Color, DoubleSide, Event, Group, Matrix4, Mesh, Object3D, PlaneGeometry, Ray, ShaderMaterial, Vector3 } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";
import { BoundingBox } from "../models/bounding-box";
import gridFragmentShader from '../shaders/grid/grid-fragment.glsl';
import gridVertexShader from '../shaders/grid/grid-vertex.glsl';



export class GridElement extends Group implements IElement {
    public key: string = "workplane" + generateUUID();
    public scene?: IScene | undefined;
    public elementType: ElementType = ElementType.Grid;
    public selectionPriority: number = -100;
    public plane!: Mesh<PlaneGeometry, ShaderMaterial>;
    public mathPlane!: Box3;
    public removeByKey: Function | undefined;

    public get object(): Object3D<Event> | undefined {
        if(!this.plane) return undefined
        return this.plane;
    } 

    constructor(
        public gridMatrix: Matrix4,
        public size: number,
        public split: number
        ) {
        super();
        this.generate();
    }
    public removeSelf(): void {
        if(this.removeByKey) {
            this.removeByKey(this.key);
        }
    }
    public addElement(element: IElement): void { }
    public removeElement(element: IElement): void { }
    public getAllElement(): IElement[] {
        return [];
    }
    public getBoundingBox(): BoundingBox | undefined {
        return new BoundingBox(this.mathPlane, this.gridMatrix);
    }
    public intersect(ray: Ray): Vector3 | undefined {
        return undefined;
        // const interaction = ray.intersectBox(this.mathPlane, new Vector3());
        // if(!interaction)
        //     return undefined;
        // return interaction;
    }
    public cloneElement(): IElement {
        var clone = super.clone();
        clone.key = this.key + "_clone";
        clone.scene = this.scene;
        return clone as IElement;
    }

    public reGenerate(): void {
        this.plane.material.uniforms["split"].value = this.split;
        this.plane.material.uniforms["size"].value = this.size;
        this.plane.material.needsUpdate = true;
    }

    private generate(): void {
        this.clear();
        //plane
        const geometryPlane = new PlaneGeometry( this.size, this.size );
        this.plane = new Mesh( geometryPlane, this.shaderMaterial() );
        this.add( this.plane );

        this.mathPlane = new Box3(new Vector3(-this.size/2, -this.size/2, -0.1), new Vector3(this.size/2, this.size/2, 0.1))
        this.mathPlane.applyMatrix4(this.gridMatrix);
        
        this.applyMatrix4(this.gridMatrix);
    }
    private shaderMaterial() : ShaderMaterial
    {
        let uniforms = {
            colorB: {type: 'vec3', value: new Color(0xffffff)},
            colorA: {type: 'vec3', value: new Color(0xffffff)},
            split: {type: 'float', value: this.split},
            size: {type: 'float', value: this.size}
        }
        return new ShaderMaterial({
            uniforms: uniforms,
            fragmentShader: gridFragmentShader,
            vertexShader: gridVertexShader,
            side: DoubleSide,
            transparent: true
          })
    }
}