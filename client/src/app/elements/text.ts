import { Box3, Color, DoubleSide, Event, Group, Matrix4, Mesh, Object3D, PlaneGeometry, Ray, ShaderMaterial, Vector3 } from "three";
import { generateUUID } from "three/src/math/MathUtils";
import { ElementType } from "../enums/element-type";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";
import fragmentShader from '../shaders/utils/text-utils.glsl';
import vertexShader from '../shaders/grid/grid-vertex.glsl';
import { BoundingBox } from "../models/bounding-box";

export class TextElement implements IElement {
    public key: string = "text_shader" + generateUUID();
    public scene?: IScene | undefined;
    public selectionPriority: number = 0;
    public elementType: ElementType = ElementType.Grid;
    public plane!: Mesh;
    public removeByKey: Function | undefined;

    public object: Object3D<Event> | undefined;

    constructor() {}
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
        return new BoundingBox();
    }
    public intersect(ray: Ray): Vector3 | undefined {
        return undefined;
    }
    public cloneElement(): IElement {
        return this;
    }
}