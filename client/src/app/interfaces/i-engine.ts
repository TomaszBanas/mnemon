import { ElementRef } from "@angular/core";
import { OrbitControls } from "three/examples/jsm/controls/OrbitControls";
import { ControlManager } from "../controls/managing/control-manager";
import { ControlMode } from "../enums/control-mode";
import { ICamera } from "./i-camera";
import { IScene } from "./i-scene";

export interface IEngine {
    camera: ICamera;
    controlManager: ControlManager;
    controls: OrbitControls;

    setCanvasContainer(canvas: ElementRef | undefined): void;
    updateCanvasSize(width: number, height: number): void;
    setCamera(camera: ICamera): void;
    setMode(mode: ControlMode): void;
    addScene(scene: IScene): void;
    getScenes(): IScene[];
    removeScene(sceneId: string): void;
    render(): void;
}