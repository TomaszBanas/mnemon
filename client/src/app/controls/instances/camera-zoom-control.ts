import { ControlArgs } from "src/app/models/control-args";
import { ControlBase } from "../base/control-base";

export class CameraZoomControl extends ControlBase {
    public override enable(data: ControlArgs): void {
        data.engine.controls.enableZoom = true;
    }
    public override disable(data: ControlArgs): void {
        data.engine.controls.enableZoom = false;
    }
    public override onWheel(data: ControlArgs): boolean { 
        data.engine.controls.update();
        data.renderNeeded = true;
        return false;
     }
}