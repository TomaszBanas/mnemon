import { LineElement } from "../elements/line-element";
import { PlaneElement } from "../elements/plane-element";
import { Line } from "../implementations/shared/models/line";
import { Plane } from "../implementations/shared/models/plane";
import { IElementEngine } from "../interfaces/i-element-engine";
import { VectorUtils } from "../utils/vector-utils";

export class PlaneElementEngine implements IElementEngine<Plane, PlaneElement>
{
    create(model: Plane): PlaneElement {
        const plane = new PlaneElement(
            VectorUtils.toVector3(model.origin),
            VectorUtils.toVector3(model.direction),
            model.borderPoints.map(x => VectorUtils.toVector3(x)),
            model.color,
            model.opacity
        );
        plane.key = model.key;
        return plane;
    }

}