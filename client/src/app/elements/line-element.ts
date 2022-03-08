import { Box3, BoxGeometry, CylinderGeometry, EdgesGeometry, Event, LineBasicMaterial, LineSegments, Matrix3, Matrix4, Mesh, MeshBasicMaterial, Object3D, Ray, Vector3 } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";
import { BoundingBox } from "../models/bounding-box";
import { GeometryGenerationUtils } from "../utils/geometry-generation-utils";
import { MatrixUtils } from "../utils/matrix-utils";

export class LineElement implements IElement {
    public key: string = "test_line_" + generateUUID();
    public scene?: IScene | undefined;
    public elementType: ElementType = ElementType.Test;
    public selectionPriority: number = 0;
    public lineMatrix!: Matrix4;
    public object: Object3D<Event> | undefined; 
    public removeByKey: Function | undefined;

    constructor(
        private from: Vector3 = new Vector3(0, 0, 0), 
        private to: Vector3 = new Vector3(1, 0, 0), 
        private thickness: number = 0.1,
        private color: number = 0x00ff00) {
            this.lineMatrix = MatrixUtils.createFromDirection(this.from.clone(), this.to.clone());
            this.object = GeometryGenerationUtils.generateLine(this.from.clone(), this.to.clone(), this.thickness, this.color);
    }
    public removeSelf(): void {
        if(this.removeByKey) {
            this.removeByKey(this.key);
        }
    }
    public addElement(element: IElement): void {
        if(this.object && element.object)
            this.object.add(element.object);
    }
    public removeElement(element: IElement): void {
        if(this.object && element.object)
            this.object.remove(element.object);
    }
    getAllElement(): IElement[] {
        return [];
    }
    getBoundingBox(): BoundingBox | undefined {
        let dir = this.to.clone().sub(this.from.clone());
        let box = new Box3(new Vector3(-dir.length()/2-(this.thickness*2), -this.thickness, -this.thickness), new Vector3(dir.length()/2, this.thickness, this.thickness))
        return new BoundingBox(box.clone(), this.lineMatrix.clone());
    }
    intersect(ray: Ray): Vector3 | undefined {
        const boxData = this.getBoundingBox();
        if(!boxData) return undefined;
        return boxData.intersect(ray);
    }
    cloneElement(): IElement {
        return this; // todo
    }

}