import { IModel } from "src/app/interfaces/i-model";
import { generateUUID } from "three/src/math/MathUtils";
import { Vector } from "./vector";

export class Grid implements IModel 
{
    public key: string = generateUUID();
    public origin!: Vector;
    public baseX!: Vector;
    public baseY!: Vector;
    public baseZ!: Vector;
}