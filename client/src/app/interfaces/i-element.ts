import { Object3D, Ray, Vector3 } from "three";
import { ElementType } from "../enums/element-type";
import { BoundingBox } from "../models/bounding-box";

export interface IElement {
    key: string;
    elementType: string | ElementType;
    object?: Object3D;
    selectionPriority: number;
    addElement(element: IElement): void;
    removeElement(element: IElement): void;
    getAllElement(): IElement[];
    getBoundingBox(): BoundingBox | undefined;
    intersect(ray: Ray): Vector3 | undefined;
    cloneElement(): IElement;
    removeSelf(): void;
    removeByKey: Function | undefined;
}