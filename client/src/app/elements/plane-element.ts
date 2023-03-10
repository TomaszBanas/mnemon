import { Box3, BoxGeometry, CylinderGeometry, EdgesGeometry, Event, LineBasicMaterial, LineSegments, Matrix3, Matrix4, Mesh, MeshBasicMaterial, Object3D, Ray, Vector3 } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";
import { BoundingBox } from "../models/bounding-box";
import { GeometryGenerationUtils } from "../utils/geometry-generation-utils";

export class PlaneElement implements IElement {
    public key: string = "plane_element_" + generateUUID();
    public scene?: IScene | undefined;
    public elementType: ElementType = ElementType.Test;
    public selectionPriority: number = 0;
    public lineMatrix!: Matrix4;
    public object: Object3D<Event> | undefined; 
    public removeByKey: Function | undefined;

    constructor(
        private origin: Vector3,
        private direction: Vector3,
        private borderPoints: Vector3[] = [],
        private color: number = 0x00ff00,
        private opacity: number = 1) {

            this.object = GeometryGenerationUtils.generatePlane(this.origin.clone(), this.direction.clone(), this.borderPoints, this.color, this.opacity);
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
        return undefined
    }
    intersect(ray: Ray): Vector3 | undefined {
        return undefined;
    }
    cloneElement(): IElement {
        return this; // todo
    }

}