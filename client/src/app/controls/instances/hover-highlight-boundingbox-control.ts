import { ControlArgs } from "../../models/control-args";
import { GeometryGenerationUtils } from "../../utils/geometry-generation-utils";
import { MatrixUtils } from "../../utils/matrix-utils";
import { Vector3 } from "three";
import { CurrentHighlightModel, HoverHighlightBaseControl } from "../base/hover-highlight-base-control";

export class HoverHighlightBoundingBoxControl extends HoverHighlightBaseControl {
    public createGeometry(data: ControlArgs, current: CurrentHighlightModel, thickness: number): void {
        const bb = current.hoveredElement.getBoundingBox();
        if(bb) {
            this.scene.scene.add(GeometryGenerationUtils.generateBB(bb.localBox, bb.transformation, 0xffffff));
            this.scene.scene.add(GeometryGenerationUtils.generatePoint(
                thickness * 0.75,
                new Vector3().applyMatrix4(bb.transformation),
                0xffffff
                ));
            this.scene.scene.add(GeometryGenerationUtils.generateArrow(
                thickness * 3,
                thickness * 1,
                thickness * 6,
                thickness * 0.5,
                bb.transformation,
                0xff0000
                ));

            this.scene.scene.add(GeometryGenerationUtils.generateArrow(
                thickness * 3,
                thickness * 1,
                thickness * 6,
                thickness * 0.5,
                bb.transformation.clone().multiply(MatrixUtils.XtoY),
                0x00ff00
            ));

            this.scene.scene.add(GeometryGenerationUtils.generateArrow(
                thickness * 3,
                thickness * 1,
                thickness * 6,
                thickness * 0.5,
                bb.transformation.clone().multiply(MatrixUtils.XtoZ),
                0x0000ff
                ));
        }
    }
    
}