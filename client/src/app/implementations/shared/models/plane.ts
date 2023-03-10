import { IModel } from "src/app/interfaces/i-model";
import { Vector } from "./vector";

export class Plane implements IModel 
{
    public key: any;
    public origin!: Vector;
    public direction!: Vector;
    public borderPoints!: Vector[];
    public color!: number;
    public opacity!: number;
}