import { Geometry } from "../../shared/models/geometry";
import { Grid } from "../../shared/models/grid";
import { Line } from "../../shared/models/line";
import { Plane } from "../../shared/models/plane";

export class MainModel
{
    public grids: Grid[] = [];
    public lines: Line[] = [];
    public planes: Plane[] = [];
    public geometries: Geometry[] = [];
}