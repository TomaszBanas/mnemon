import { ControlArgs } from "../../models/control-args";
import { ControlBase } from "../base/control-base";

export class DeleteControl extends ControlBase {
    public override onKeyUp(keyCode: string, data: ControlArgs): boolean { 
        if(keyCode === "Delete" && data.cursor.object) {
            data.cursor.object.removeSelf();
        }
        return false;
     }
}