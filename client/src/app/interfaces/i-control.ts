import { ControlArgs } from "../models/control-args";

export interface IControl {
    enable(data: ControlArgs): void;
    disable(data: ControlArgs): void;

    onMouseDown(keyCode: number, data: ControlArgs): boolean;
    onMouseUp(keyCode: number, data: ControlArgs): boolean;
    onMouseMove(data: ControlArgs): boolean;

    onWheel(data: ControlArgs): boolean;

    onClick(data: ControlArgs): boolean;
    onDoubleClick(data: ControlArgs): boolean;
    onRightClick(data: ControlArgs): boolean;
    onMiddleClick(data: ControlArgs): boolean;
    
    onKeyDown(keyCode: string, data: ControlArgs): boolean;
    onKeyUp(keyCode: string, data: ControlArgs): boolean;
    onKeyPress(keyCode: string, data: ControlArgs): boolean;
}