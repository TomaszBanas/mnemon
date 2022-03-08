import { LineElement } from "../elements/line-element";
import { Line } from "../implementations/shared/models/line";
import { IElementEngine } from "../interfaces/i-element-engine";
import { VectorUtils } from "../utils/vector-utils";

export class LineElementEngine implements IElementEngine<Line, LineElement>
{
    create(model: Line): LineElement {
        const line = new LineElement(
            VectorUtils.toVector3(model.start),
            VectorUtils.toVector3(model.end),
            model.thickness, 
            model.color
            );
        line.key = model.key;
        return line;
    }
    
}