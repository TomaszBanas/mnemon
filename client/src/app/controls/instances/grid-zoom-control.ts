import { ElementType } from "../../enums/element-type";
import { IElement } from "../../interfaces/i-element";
import { ControlArgs } from "../../models/control-args";
import { OrthographicCamera } from "three";
import { ControlBase } from "../base/control-base";
import { ElementZoomControl } from "../base/element-zoom-control";
import { GridElement } from "src/app/elements/grid-element";

export class GridZoomControl extends ElementZoomControl<GridElement> {

    public elementType: ElementType = ElementType.Grid;

    public handle(elements: GridElement[], data: ControlArgs): void {
        const orthogonal = data.engine.camera.instance as OrthographicCamera
        if(!orthogonal)
            return;
        var split = this.calculateSplit(orthogonal)
        for (const grid of elements)  {
            if(grid.split != split) {
                grid.split = split;
                grid.reGenerate();
                data.renderNeeded = true;
            }
        }
    }

    private calculateSplit(orthogonal: OrthographicCamera): number {
        var split = Math.round(1 / orthogonal.zoom * 800) / 4;
        if(split < 0.05)
            split = 0.05;
        if(split > 10)
            split = 10;
        return split;
    }
}