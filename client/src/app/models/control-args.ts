import { ICursor } from "../interfaces/i-cursor";
import { IEngine } from "../interfaces/i-engine";

export class ControlArgs {
    public cursor!: ICursor;
    public engine!: IEngine;
    public event!: any;
    public renderNeeded: boolean = false;

    constructor(cursor: ICursor, engine: IEngine, event: any) {
        this.cursor = cursor;
        this.engine = engine;
        this.event = event;
    }
}