import { IControl } from "src/app/interfaces/i-control";
import { ControlArgs } from "src/app/models/control-args";

export abstract class ControlBase implements IControl {
    public enable(data: ControlArgs): void {

    }
    public disable(data: ControlArgs): void {

    }
    public onMouseDown(keyCode: number, data: ControlArgs): boolean { 
        return false;
     }
    public onMouseUp(keyCode: number, data: ControlArgs): boolean { 
        return false;
     }
    public onMouseMove(data: ControlArgs): boolean { 
        return false;
    }
    public onWheel(data: ControlArgs): boolean { 
        return false;
    }
    public onClick(data: ControlArgs): boolean { 
        return false;
     }
    public onDoubleClick(data: ControlArgs): boolean { 
        return false;
     }
    public onRightClick(data: ControlArgs): boolean { 
        return false;
     }
    public onMiddleClick(data: ControlArgs): boolean { 
        return false;
     }
    public onKeyDown(keyCode: string, data: ControlArgs): boolean { 
        return false;
     }
    public onKeyUp(keyCode: string, data: ControlArgs): boolean { 
        return false;
     }
    public onKeyPress(keyCode: string, data: ControlArgs): boolean { 
        return false;
     }

}