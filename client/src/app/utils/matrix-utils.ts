import { Matrix4, Vector3 } from "three";

export class MatrixUtils
{
    public static create(
        baseX: Vector3,
        baseY: Vector3,
        baseZ: Vector3,
        origin: Vector3
    ): Matrix4 {
        return new Matrix4().set(
            baseX.x,
            baseY.x,
            baseZ.x,
            origin.x,
            baseX.y,
            baseY.y,
            baseZ.y,
            origin.y,
            baseX.z,
            baseY.z,
            baseZ.z,
            origin.z,
            0,
            0,
            0,
            1
        );
    }
    public static createFromOrigin(
        origin: Vector3
    ): Matrix4 {
        return this.create(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            origin
          );
    }
    public static createFromDirection(
        start: Vector3,
        end: Vector3
    ): Matrix4 {
        let baseX = end.clone().sub(start.clone());
        baseX.normalize();
        let baseY = new Vector3(0, 0, 1);
        if(baseX.clone().cross(baseY.clone()).length() === 0)
            baseY = new Vector3(0, 1, 0);
        let baseZ = baseX.clone().cross(baseY.clone());
        baseZ.normalize();
        baseY = baseX.clone().cross(baseZ.clone());
        baseY.normalize();
        return this.create(
            baseX,
            baseY,
            baseZ,
            end.clone().add(start).divideScalar(2)
          );
    }
    public static get ZtoX(): Matrix4 {
        return this.create(
            new Vector3(0, 0, -1),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, 0)
          );
    }
    public static get XtoZ(): Matrix4 {
        return this.create(
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, 0)
          );
    }
    public static get XtoY(): Matrix4 {
        return this.create(
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, 0)
          );
    }
    public static get YtoX(): Matrix4 {
        return this.create(
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, 0)
          );
    }
    public static get default(): Matrix4 {
        return this.create(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, 0)
          );
    }
}