import { Scene, WebGLRenderer } from "three";
import { ICamera } from "../interfaces/i-camera";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";

export class MainScene implements IScene {
    public key: string = "MainScene";
    public priority: number = 10;

    private scene?: Scene;
    private elements: IElement[] = [];

    constructor() {
        this.scene = new Scene();
    }
    public getAllElement(): IElement[] {
        return this.elements;
    }
    public render(renderer: WebGLRenderer, camera: ICamera): void {
        if(!this.scene) return;
        renderer.render(this.scene, camera.instance);
    }

    public addElement(element: IElement): void {
        this.elements.push(element);
        if(element.object) this.scene?.add(element.object);
    }
    public removeElement(element: IElement): void {
        const elementData = this.elements.find(x => x.key === element.key);
        if(!elementData) return;
        this.elements = this.elements.filter(x => x.key !== element.key);
        if(elementData.object) this.scene?.remove(elementData.object);
    }
}