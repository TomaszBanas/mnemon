import { IModel } from "src/app/interfaces/i-model";
import { Vector } from "./vector";

export class Line implements IModel 
{
    public key: any;
    public start!: Vector;
    public end!: Vector;
    public thickness!: number;
    public color!: number;
}