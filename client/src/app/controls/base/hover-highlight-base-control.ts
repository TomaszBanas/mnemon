import { Matrix4, Mesh, MeshBasicMaterial, Vector3 } from "three";
import { IElement } from "../../interfaces/i-element";
import { ControlArgs } from "../../models/control-args";
import { HighlightScene } from "../../scenes/highlight-scene";
import { ControlBase } from "./control-base";

export class CurrentHighlightModel
{
    thickness!: number;
    hoveredElement!: IElement;
    object!: any;
}

export abstract class HoverHighlightBaseControl extends ControlBase {
    public scene: HighlightScene = new HighlightScene();
    private current?: CurrentHighlightModel | null;
    public override enable(data: ControlArgs): void {
        data.engine.addScene(this.scene);
    }

    public override disable(data: ControlArgs): void {
        data.engine.removeScene(this.scene.key);
    }

    public override onMouseMove(data: ControlArgs): boolean {
        this.handle(data);
        return false;
    }
    public override onWheel(data: ControlArgs): boolean {
        this.handle(data);
        return false;
    }

    public abstract createGeometry(data: ControlArgs, current: CurrentHighlightModel, thickness: number): void;

    private handle(data: ControlArgs): void {
        const thickness = 5 / (data.engine.camera as any).zoom;
        var hoveredElement = data.cursor.object;
        
        if(hoveredElement && this.current && hoveredElement.key === this.current.hoveredElement.key && this.current.thickness === thickness)
            return;

        if(this.current) {
            this.scene.clearScene.clear();
            this.scene.scene.clear();
            this.current = null;
            data.renderNeeded = true;
        }

        if(!hoveredElement || !hoveredElement.object) return;
        var object = hoveredElement.object;
        if(!object) return;

        this.current = new CurrentHighlightModel();
        this.current.hoveredElement = hoveredElement;
        this.current.object = object;
        this.current.thickness = thickness;

        if(this.current)
            this.createGeometry(data, this.current, thickness);
        data.renderNeeded = true;
    }
}