import { Cursor3D } from "../../cursor/cursor-3d";
import { IControl } from "../../interfaces/i-control";
import { ICursor } from "../../interfaces/i-cursor";
import { IEngine } from "../../interfaces/i-engine";
import { ControlArgs } from "../../models/control-args";

export class ControlManager {
    private activeControls: IControl[] = [];
    private domElement!: HTMLCanvasElement;
    private engine!: IEngine;
    private cursor!: ICursor;

    private getControlArgs(event: any): ControlArgs {
        return new ControlArgs(this.cursor, this.engine, event);
    }

    constructor(domElement: HTMLCanvasElement, engine: IEngine) {
        this.domElement = domElement;
        this.engine = engine;
        this.cursor = new Cursor3D(this.engine);
        this.subscribeToEvents();
    }
    public setActiveControls(controls: IControl[]) {
        this.internal_disable();
        this.activeControls = controls;
        this.internal_enable();
    }
    private clearSubscriptions(): void {
        window.removeEventListener("keydown", this.internal_onkeydown);
        window.removeEventListener("keypress", this.internal_onkeypress);
        window.removeEventListener("keyup", this.internal_onkeyup);
        this.domElement.removeEventListener("click", this.internal_onclick);
        this.domElement.removeEventListener("dblclick", this.internal_ondblclick);
        this.domElement.removeEventListener("mousedown", this.internal_onmousedown);
        this.domElement.removeEventListener("mousemove", this.internal_onmousemove);
        this.domElement.removeEventListener("mouseup", this.internal_onmouseup);
        this.domElement.removeEventListener("wheel", this.internal_onwheel);
    }
    private subscribeToEvents(): void {
        this.clearSubscriptions();
        window.addEventListener("keydown", this.internal_onkeydown.bind(this));
        window.addEventListener("keypress", this.internal_onkeypress.bind(this));
        window.addEventListener("keyup", this.internal_onkeyup.bind(this));
        this.domElement.addEventListener("click", this.internal_onclick.bind(this));
        this.domElement.addEventListener("dblclick", this.internal_ondblclick.bind(this));
        this.domElement.addEventListener("mousedown", this.internal_onmousedown.bind(this));
        this.domElement.addEventListener("mousemove", this.internal_onmousemove.bind(this));
        this.domElement.addEventListener("mouseup", this.internal_onmouseup.bind(this));
        this.domElement.addEventListener("wheel", this.internal_onwheel.bind(this));
    }
    private internal_disable(){
        const data = this.getControlArgs(null);
        for (const control of this.activeControls) {
            control.disable(data);
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_enable(){
        const data = this.getControlArgs(null);
        for (const control of this.activeControls) {
            control.enable(data);
        }
        if(data.renderNeeded)
            data.engine.render();
    }

    private internal_onkeydown(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onKeyDown(event.code, data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onkeypress(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onKeyPress(event.code, data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onkeyup(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onKeyUp(event.code, data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onclick(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = false;
            switch(event.button)
            {
                case 0:
                    handled = control.onClick(data);
                    break;
                case 1:
                    handled = control.onMiddleClick(data);
                    break;
                case 2:
                    handled = control.onRightClick(data);
                    break;
            }
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_ondblclick(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onDoubleClick(data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onmouseup(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onMouseUp(event.button, data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onmousedown(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onMouseDown(event.button, data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onmousemove(event: any){
        const data = this.getControlArgs(event);
        const mouseX = ( event.offsetX / this.domElement.width ) * 2 - 1;
	    const mouseY = - ( event.offsetY / this.domElement.height ) * 2 + 1;
        this.cursor.updateFromMouse(mouseX, mouseY);
        for (const control of this.activeControls) {
            let handled = control.onMouseMove(data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
    private internal_onwheel(event: any){
        const data = this.getControlArgs(event);
        for (const control of this.activeControls) {
            let handled = control.onWheel(data);
            if(handled)
                break;
        }
        if(data.renderNeeded)
            data.engine.render();
    }
}