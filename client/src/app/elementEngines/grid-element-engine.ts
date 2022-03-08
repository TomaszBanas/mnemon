import { GridElement } from "../elements/grid-element";
import { Grid } from "../implementations/shared/models/grid";
import { IElementEngine } from "../interfaces/i-element-engine";
import { MatrixUtils } from "../utils/matrix-utils";
import { VectorUtils } from "../utils/vector-utils";

export class GridElementEngine implements IElementEngine<Grid, GridElement>
{
    create(model: Grid): GridElement {
        const gridMatrix = MatrixUtils.create(
            VectorUtils.toVector3(model.baseX),
            VectorUtils.toVector3(model.baseY),
            VectorUtils.toVector3(model.baseZ),
            VectorUtils.toVector3(model.origin)
        );
        const grid = new GridElement(gridMatrix, 100, 1);
        grid.key = model.key;
        return grid;
    }
    
}