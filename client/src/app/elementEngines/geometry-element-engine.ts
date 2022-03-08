import { generateUUID } from "three/src/math/MathUtils";
import { GeometryElement } from "../elements/geometry-element";
import { Geometry } from "../implementations/shared/models/geometry";
import { Line } from "../implementations/shared/models/line";
import { Vector } from "../implementations/shared/models/vector";
import { IElementEngine } from "../interfaces/i-element-engine";
import { LineElementEngine } from "./line-element-engine";

export class GeometryElementEngine implements IElementEngine<Geometry, GeometryElement>
{
    create(model: Geometry): GeometryElement {
        const element = new GeometryElement(
            model.vertices.array,
            model.indexes.array,
            model.normals.array,
            model.colors.array
        );
        element.key = model.key;
        return element;
    }
}