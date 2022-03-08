import { IModel } from "src/app/interfaces/i-model";
import { Vector } from "./vector";

export class Geometry implements IModel
{
    public key: any;
    public normals!: GeometryArray;
    public vertices!: GeometryArray;
    public indexes!: GeometryArray;
    public colors!: GeometryArray;
}
export class GeometryArray
{
    public array!: number[];
    public itemSize!: number;
    public count!: number;
}
export class Line
{
    public start!: Vector;
    public end!: Vector;
}