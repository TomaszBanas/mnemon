import { Event, Object3D, Ray, Vector3 } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { BoundingBox } from "../models/bounding-box";

export class ThreeJsObject implements IElement {
    public key: string = generateUUID();
    public elementType: ElementType = ElementType.Unknown;
    public selectionPriority: number = 1;
    public data!: Object3D<Event>;
    public removeByKey: Function | undefined;
    public get object(): Object3D<Event> | undefined {
        return this.data;
    } 
    constructor(data: Object3D<Event>) {
            this.data = data;
    }
    public removeSelf(): void {
        if(this.removeByKey) {
            this.removeByKey(this.key);
        }
    }
    public addElement(element: IElement): void {
        if(element.object)
            this.data.add(element.object);
    }
    public removeElement(element: IElement): void {
        if(element.object)
        this.data.remove(element.object);
    }
    getAllElement(): IElement[] {
        return [];
    }
    getBoundingBox(): BoundingBox | undefined {
        return undefined;
    }
    intersect(ray: Ray): Vector3 | undefined {
        return undefined;
    }
    cloneElement(): IElement {
        return new ThreeJsObject(this.data.clone());
    }

}