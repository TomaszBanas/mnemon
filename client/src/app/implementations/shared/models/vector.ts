import { Vector3 } from "three";

export class Vector
{
    public x!: number;
    public y!: number;
    public z!: number;

    constructor(
        x: number | Vector3 | undefined = undefined,
        y: number | undefined = undefined,
        z: number | undefined = undefined
    )
    {
        if(!x && !y && !z)
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        else if(x instanceof Vector3)
        {
            this.x = x.x;
            this.y = x.y;
            this.z = x.z;
        }else {
            this.x = x as number;
            this.y = y as number;
            this.z = z as number;
        }
    }
}