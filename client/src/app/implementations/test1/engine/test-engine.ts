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
import { Plane } from "../../shared/models/plane";
import { PlaneElement } from "src/app/elements/plane-element";
import { PlaneElementEngine } from "src/app/elementEngines/plane-element-engine";

export class TestEngine extends ViewerEngine
{
    private scene: IScene = new MainScene();
    private visualizations: ComponentVisualization[] = [];

    public gridsData!: EngineArray<Grid, GridElement>;
    public linesData!: EngineArray<Line, LineElement>;
    public planesData!: EngineArray<Plane, PlaneElement>;
    public geometriesData!: EngineArray<Geometry, GeometryElement>;

    constructor(renderer: WebGLRenderer) {
        super(renderer);
        this.addScene(this.scene);
    }

    public updateModels(models: MainModel[]): void {
        this.clearModels();
        for (const m of models) {
            const vis = new ComponentVisualization(this.scene, this);
            vis.setModel(m);
            this.visualizations.push(vis);
        }
    }
    public clearModels(): void {
        for (const vis of this.visualizations) {
            vis.clear();
        }
        this.visualizations = [];
    }
}


export class ComponentVisualization
{
    private model!: MainModel;


    public gridsData!: EngineArray<Grid, GridElement>;
    public linesData!: EngineArray<Line, LineElement>;
    public planesData!: EngineArray<Plane, PlaneElement>;
    public geometriesData!: EngineArray<Geometry, GeometryElement>;

    constructor(
        private scene: IScene, 
        private engine: ViewerEngine) {

    }

    public setModel(model: MainModel): void {
        this.clear();
        this.model = model;

        const grids = new ViewerArray<Grid, GridElement>(this.scene, this.engine, new GridElementEngine());
        this.gridsData = new EngineArray<Grid, GridElement>(this.model.grids, grids);

        const lines = new ViewerArray<Line, LineElement>(this.scene, this.engine, new LineElementEngine());
        this.linesData = new EngineArray<Line, LineElement>(this.model.lines, lines);
        
        const planes = new ViewerArray<Plane, PlaneElement>(this.scene, this.engine, new PlaneElementEngine());
        this.planesData = new EngineArray<Plane, PlaneElement>(this.model.planes, planes);

        const geometries = new ViewerArray<Geometry, GeometryElement>(this.scene, this.engine, new GeometryElementEngine());
        this.geometriesData = new EngineArray<Geometry, GeometryElement>(this.model.geometries, geometries);
    }
    public clear(): void {
        this.gridsData?.clear();
        this.linesData?.clear();
        this.geometriesData?.clear();
        this.planesData?.clear();
    }
}