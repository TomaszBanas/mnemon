import { Ray, Vector2, Vector3 } from "three";
import { IElement } from "./i-element";

export interface ICursor {
    mouseScreenPosition?: Vector2;
    mousePosition?: Vector3;
    position?: Vector3;
    interactedObjects: {point: Vector3, element: IElement}[];
    object?: IElement;
    lastRay?: Ray;
    updateFromMouse(mouseX: number, mouseY: number): void
    update(ray: Ray): void;
}