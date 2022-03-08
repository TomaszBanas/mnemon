import { IScene } from "../../../interfaces/i-scene";
import { MainScene } from "../../../scenes/main-scene";
import { WebGLRenderer } from "three";
import { ViewerEngine } from "../../../engine/viewer-engine";
import { ViewerArray } from "src/app/models/viewer-array";
import { GridElement } from "src/app/elements/grid-element";
import { Grid } from "../../shared/models/grid";
import { GridElementEngine } from "src/app/elementEngines/grid-element-engine";
import { LineElement } from "src/app/elements/line-element";
import { LineElementEngine } from "src/app/elementEngines/line-element-engine";
import { Line } from "../../shared/models/line";
import { MainModel } from "../models/main-model";
import { EngineArray } from "src/app/models/engine-array";
import { GeometryElement } from "src/app/elements/geometry-element";
import { GeometryElementEngine } from "src/app/elementEngines/geometry-element-engine";
import { Geometry } from "../../shared/models/geometry";

export class TestEngine extends ViewerEngine
{
    private scene: IScene = new MainScene();
    private model!: MainModel;

    public gridsData!: EngineArray<Grid, GridElement>;
    public linesData!: EngineArray<Line, LineElement>;
    public geometriesData!: EngineArray<Geometry, GeometryElement>;

    constructor(model: MainModel, renderer: WebGLRenderer) {
        super(renderer);
        this.addScene(this.scene);
        this.updateModel(model);
    }

    public updateModel(model: MainModel): void {
        this.clear();
        this.model = model;

        const grids = new ViewerArray<Grid, GridElement>(this.scene, this, new GridElementEngine());
        this.gridsData = new EngineArray<Grid, GridElement>(this.model.grids, grids);

        const lines = new ViewerArray<Line, LineElement>(this.scene, this, new LineElementEngine());
        this.linesData = new EngineArray<Line, LineElement>(this.model.lines, lines);

        const geometries = new ViewerArray<Geometry, GeometryElement>(this.scene, this, new GeometryElementEngine());
        this.geometriesData = new EngineArray<Geometry, GeometryElement>(this.model.geometries, geometries);
    }
    public clear(): void {
        this.gridsData?.clear();
        this.linesData?.clear();
        this.geometriesData?.clear();
    }
}