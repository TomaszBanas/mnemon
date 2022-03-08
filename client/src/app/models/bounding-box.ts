import { Box3, Matrix4, Ray, Vector3 } from "three";
import { MatrixUtils } from "../utils/matrix-utils";

export class BoundingBox {
    public localBox!: Box3;
    public transformation!: Matrix4;
    public get transformationInverted(): Matrix4 {
        return this.transformation.clone().invert();
    };

    constructor(localBox = new Box3(), transformation = MatrixUtils.default)
    {
        this.localBox = localBox;
        this.transformation = transformation;
    }

    public intersect(ray: Ray): Vector3 | undefined {
        let inversedMatrix = this.transformation.clone().invert();
        let intesection = ray.clone().applyMatrix4(inversedMatrix).intersectBox(this.localBox, new Vector3());
        if(!intesection) return undefined;
        return intesection;
    }

}