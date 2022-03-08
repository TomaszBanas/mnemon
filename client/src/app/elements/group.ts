import { Object3D, BoxGeometry, Mesh, Event, Box3, MeshBasicMaterial, Vector3, Group, Ray } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";
import { BoundingBox } from "../models/bounding-box";

export class CustomGroup extends Group implements IElement {
    public key!: string;
    public elementType: ElementType = ElementType.Group;
    public selectionPriority: number = -100;
    public scene?: IScene | undefined;
    public removeByKey: Function | undefined;
    public get object(): Object3D<Event> | undefined {
        return this;
    }    

    private elements: IElement[] = [];

    constructor(groupName: string) {
        super();
        this.key = groupName + generateUUID();
    }
    public removeSelf(): void {
        if(this.removeByKey) {
            this.removeByKey(this.key);
        }
    }
    public addElement(element: IElement): void {
        if(this.containsElement(element)) return;
        this.elements.push(element);
        if(element.object)
            this.add(element.object);
    }
    public removeElement(element: IElement): void {
        if(!this.containsElement(element)) return;
        this.elements = this.elements.filter(x => x.key !== element.key);
        if(element.object)
            this.remove(element.object);
    }
    public getBoundingBox(): BoundingBox | undefined {
        return undefined;
    }
    public cloneElement(): IElement
    {
        var clone = super.clone();
        clone.key = this.key + "_clone";
        clone.scene = this.scene;
        return clone as IElement;
    }
    public getAllElement(): IElement[] {
        return this.elements;
    }
    public intersect(ray: Ray): Vector3 | undefined {
        return undefined;
    }

    private containsElement(element: IElement): boolean {
        return this.elements.some(x => x.key === element.key);
    }
}