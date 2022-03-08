import { ControlArgs } from "../../models/control-args";
import { ControlBase } from "../base/control-base";

export class CameraMoveControl extends ControlBase {
    private isKeyPressed = false;

    public override enable(data: ControlArgs): void {
        data.engine.controls.enableRotate = true;
    }
    public override disable(data: ControlArgs): void {
        data.engine.controls.enableRotate = false;
    }

    public override onMouseDown(keyCode: number, data: ControlArgs): boolean {
        this.isKeyPressed = true;
        return false;
    }
    public override onMouseUp(keyCode: number, data: ControlArgs): boolean {
        this.isKeyPressed = false;
        return false;
    }
    public override onMouseMove(data: ControlArgs): boolean {
        if(this.isKeyPressed) {
            data.engine.controls.update();
            data.renderNeeded = true;
        }
        return false;
     }
}