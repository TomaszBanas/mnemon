import { Vector3 } from "three";

export class VectorUtils
{
    public static toVector3(v: any): Vector3
    {
        return new Vector3(v.x, v.y, v.z);
    }
}