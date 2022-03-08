import { Vector2, Vector3, Ray, Raycaster } from "three";
import { ICursor } from "../interfaces/i-cursor";
import { IElement } from "../interfaces/i-element";
import { IEngine } from "../interfaces/i-engine";

export class Cursor3D implements ICursor {
    public mouseScreenPosition?: Vector2 | undefined;
    public mousePosition?: Vector3 | undefined;
    public position?: Vector3 | undefined;
    public interactedObjects: {point: Vector3, element: IElement}[] = [];
    public object?: IElement | undefined;
    public lastRay?: Ray;
    private engine!: IEngine;

    constructor(engine: IEngine) {
        this.engine = engine;
    }

    public updateFromMouse(mouseX: number, mouseY: number): void {

        const raycaster = new Raycaster();
        const mouse = {
            x: mouseX,
            y: mouseY,
        }
        raycaster.setFromCamera(mouse, this.engine.camera.instance);
        this.update(raycaster.ray);
    }

    public update(ray: Ray): void {
        this.lastRay = ray;
        this.clearData();
        for (const scene of this.engine.getScenes()) {
            this.handleElements(ray, scene.getAllElement());
        }
        if(this.interactedObjects.length > 0) {
            this.interactedObjects.sort((a, b) => {
                if(b.element.selectionPriority !== a.element.selectionPriority)
                    return b.element.selectionPriority - a.element.selectionPriority
                return ray.origin.distanceTo(a.point) - ray.origin.distanceTo(b.point);
            });
            const object = this.interactedObjects[0];
            this.object = object.element;
            this.position = object.point;
        }
    }


    private clearData(): void {
        this.mouseScreenPosition = undefined;
        this.mousePosition = undefined;
        this.position = undefined;
        this.interactedObjects = [];
        this.object = undefined;
    }

    private handleElements(ray: Ray, elements: IElement[]): void {
        for (const element of elements) {
            var intesecton = element.intersect(ray);
            if(intesecton)
                this.interactedObjects.push({point: intesecton, element: element});
            this.handleElements(ray, element.getAllElement());
        }
    }

}