import { LEADING_TRIVIA_CHARS } from "@angular/compiler/src/render3/view/template";
import { ElementRef } from "@angular/core";
import { WebGLRenderer } from "three";
import { OrbitControls } from "three/examples/jsm/controls/OrbitControls";
import { generateUUID } from "three/src/math/MathUtils";
import { ControlManager } from "../controls/managing/control-manager";
import { ControlMode } from "../enums/control-mode";
import { ControlsFactory } from "../controls/managing/controls-factory";
import { ICamera } from "../interfaces/i-camera";
import { IEngine } from "../interfaces/i-engine";
import { IScene } from "../interfaces/i-scene";

export class ViewerEngine implements IEngine {

    private renderer!: WebGLRenderer;
    private canvasContainer!: ElementRef<any> | undefined;
    private scenes: IScene[] = [];
    public camera!: ICamera;
    public controlManager!: ControlManager;
    public controls!: OrbitControls;

    constructor(renderer: WebGLRenderer) {
        this.renderer = renderer;
    }
    public setMode(mode: ControlMode): void {
        const factory = new ControlsFactory();
        this.controlManager.setActiveControls(factory.handle(mode));
    }
    public getScenes(): IScene[] {
        return this.scenes;
    }
    public setCanvasContainer(canvasContainer: ElementRef<any> | undefined): void {
        this.canvasContainer = canvasContainer
        if(!this.canvasContainer) return;
        this.renderer.domElement.style.position = 'absolute';
        this.canvasContainer.nativeElement.appendChild(this.renderer.domElement);
        this.updateCanvasSizeInternal(this.canvasContainer.nativeElement.clientWidth, this.canvasContainer.nativeElement.clientHeight);
        this.controls = new OrbitControls(this.camera.instance, this.renderer.domElement);
        this.controlManager = new ControlManager(this.renderer.domElement, this);
        this.setMode(ControlMode.Preview);
        this.render();
    }
    public updateCanvasSize(width: number, height: number): void {
        this.updateCanvasSizeInternal(width, height);
        this.render();
    }
    public setCamera(camera: ICamera): void {
        this.camera = camera;
        if(this.canvasContainer)
            this.updateCanvasSizeInternal(this.canvasContainer.nativeElement.clientWidth, this.canvasContainer.nativeElement.clientHeight);
        this.render();
    }
    public addScene(scene: IScene): void {
        if(!scene.key) throw "Scene do not have key";
        this.scenes.push(scene);
        this.sortScenes();
        this.render();
    }
    public removeScene(sceneId: string): void {
        this.scenes = this.scenes.filter(x => x.key != sceneId);
        this.sortScenes();
        this.render();
    }
    public render(): void {
        if(!this.canvasContainer) return;
        this.renderer.clear();
        for (const scene of this.scenes) {
            scene.render(this.renderer, this.camera);
        }
    }


    private sortScenes = () => this.scenes.sort((a, b) => a.priority - b.priority);

    public updateCanvasSizeInternal(width: number, height: number): void {
        if(!this.canvasContainer) return;
        if(this.renderer)
            this.renderer.setSize(width, height);
        if(this.camera)
            this.camera.update(width, height);
    }
}