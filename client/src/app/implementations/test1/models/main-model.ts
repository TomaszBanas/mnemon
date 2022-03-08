import { Geometry } from "../../shared/models/geometry";
import { Grid } from "../../shared/models/grid";
import { Line } from "../../shared/models/line";

export class MainModel
{
    public grids: Grid[] = [];
    public lines: Line[] = [];
    public geometries: Geometry[] = [];
}