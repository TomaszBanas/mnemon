import { IControl } from "src/app/interfaces/i-control";
import { CameraMoveControl } from "../instances/camera-move-control";
import { CameraZoomControl } from "../instances/camera-zoom-control";
import { ControlMode } from "../../enums/control-mode";
import { GridZoomControl } from "../instances/grid-zoom-control";
import { HoverHighlightOutlineControl } from "../instances/hover-highlight-outline-control";
import { HoverHighlightBoundingBoxControl } from "../instances/hover-highlight-boundingbox-control";
import { DeleteControl } from "../instances/delete-control";

export class ControlsFactory {

    private instances = {
        cameraZoom: new CameraZoomControl(),
        cameraMove: new CameraMoveControl(),
        gridZoom: new GridZoomControl(),
        hoverHighlightOutline: new HoverHighlightOutlineControl(),
        hoverHighlightBoundingBox: new HoverHighlightBoundingBoxControl(),
        delete: new DeleteControl(),
    }

    public handle(mode: ControlMode) : IControl[] {
        var response: IControl[] = [];
        switch(mode) {
            case ControlMode.Preview:
                response.push(this.instances.cameraZoom);
                response.push(this.instances.cameraMove);
                response.push(this.instances.gridZoom);
                response.push(this.instances.hoverHighlightOutline);
                break;
            case ControlMode.Select:
                response.push(this.instances.cameraZoom);
                response.push(this.instances.hoverHighlightOutline);
                response.push(this.instances.delete);
                break;
            case ControlMode.Debug:
                response.push(this.instances.cameraZoom);
                response.push(this.instances.cameraMove);
                response.push(this.instances.gridZoom);
                response.push(this.instances.hoverHighlightBoundingBox);
                response.push(this.instances.delete);
                break;
        }
        
        return response;
    }
}