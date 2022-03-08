import { ElementType } from "src/app/enums/element-type";
import { IElement } from "src/app/interfaces/i-element";
import { ControlArgs } from "src/app/models/control-args";
import { ControlBase } from "./control-base";

export abstract class ElementZoomControl<T> extends ControlBase {

    public abstract elementType: ElementType;

    public abstract handle(elements: T[], data: ControlArgs): void;

    public override onWheel(data: ControlArgs): boolean { 
        const results: IElement[] = [];
        for (const scene of data.engine.getScenes()) {
            this.handleElements(scene.getAllElement(), results);
        }
        const elements = results.map(x => (x as any) as T).filter(x => x);
        if(elements && elements.length > 0)
            this.handle(elements, data);
        return false;
    }

    
    private handleElements(elements: IElement[], result: IElement[]): void {
        for (const element of elements) {
            if(element.elementType === this.elementType) 
                result.push(element)
            this.handleElements(element.getAllElement(), result);
        }
    }
}