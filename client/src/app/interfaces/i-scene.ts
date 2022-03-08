import { Scene, WebGLRenderer } from "three";
import { ICamera } from "./i-camera";
import { IElement } from "./i-element";

export interface IScene {
    key: string;
    priority: number;
    render(renderer: WebGLRenderer, camera: ICamera): void;
    addElement(element: IElement): void;
    removeElement(element: IElement): void;
    getAllElement(): IElement[];
}