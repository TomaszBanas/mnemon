import { Color, Scene, WebGLRenderer } from "three";
import { ICamera } from "../interfaces/i-camera";
import { IElement } from "../interfaces/i-element";
import { IScene } from "../interfaces/i-scene";

export class HighlightScene implements IScene {
    public key: string = "HighlightScene";
    public priority: number = 100;

    public clearScene: Scene;
    public scene: Scene;
    constructor() {
        this.clearScene = new Scene();
        this.scene = new Scene();
    }
    public getAllElement(): IElement[] {
        return [];
    }
    public render(renderer: WebGLRenderer, camera: ICamera): void {
        if(!this.clearScene) return;
        if(!this.scene) return;
        if(!(this.clearScene.children.length > 0 || this.scene.children.length > 0 )) return;



        var gl = renderer.context;
        gl.colorMask(false, false, false, false);
        gl.depthMask(false);
        gl.enable(gl.STENCIL_TEST);
        gl.stencilOp(gl.REPLACE, gl.REPLACE, gl.REPLACE);
        gl.stencilFunc(gl.ALWAYS, 1, 0xffffffff);
        gl.clearStencil(0);
        renderer.render(this.clearScene, camera.instance);
        gl.colorMask(true, true, true, true);
        gl.depthMask(true);
        gl.stencilOp(gl.REPLACE, gl.REPLACE, gl.REPLACE);
        gl.stencilFunc(gl.NOTEQUAL, 1, 0xffffffff);
        gl.disable(gl.DEPTH_TEST);
        renderer.render(this.scene, camera.instance);
        gl.enable(gl.DEPTH_TEST);
        gl.disable(gl.STENCIL_TEST);


    }

    public addElement(element: IElement): void { }
    public removeElement(element: IElement): void { }
}