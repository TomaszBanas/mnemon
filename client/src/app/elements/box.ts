import { Object3D, BoxGeometry, Mesh, Event, Box3, MeshBasicMaterial, Vector3, Ray } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";
import { BoundingBox } from "../models/bounding-box";

export class BoxElement extends Mesh implements IElement {
    public key: string = "test_box_" + generateUUID();
    public elementType: ElementType = ElementType.Test;
    public selectionPriority: number = 0;
    public scene?: IScene | undefined;
    public removeByKey: Function | undefined;
    public get object(): Object3D<Event> | undefined {
        return this;
    }    

    constructor(size: Vector3 = new Vector3(1, 1, 1), color: number = 0x00ff00) {
        super(new BoxGeometry(size.x, size.y, size.z), new MeshBasicMaterial({ color: color}));
    }
    public removeSelf(): void {
        if(this.removeByKey) {
            this.removeByKey(this.key);
        }
    }
    public intersect(ray: Ray): Vector3 | undefined {
        return undefined;
    }
    public getAllElement(): IElement[] {
        return [];
    }
    public addElement(element: IElement): void {
        if(element.object)
            this.add(element.object);
    }
    public removeElement(element: IElement): void {
        if(element.object)
            this.remove(element.object);
    }
    public getBoundingBox(): BoundingBox | undefined {
        return new BoundingBox(new Box3(new Vector3(-0.5, -0.5, -0.5), new Vector3(0.5, 0.5, 0.5)));
    }
    public cloneElement(): IElement
    {
        var clone = super.clone();
        clone.key = this.key + "_clone";
        clone.scene = this.scene;
        return clone as IElement;
    }
}