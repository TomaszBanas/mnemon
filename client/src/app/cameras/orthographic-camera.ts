import { OrthographicCamera } from "three";
import { ICamera } from "../interfaces/i-camera";

export class CustomOrthographicCamera extends OrthographicCamera implements ICamera {
    public get instance(): OrthographicCamera {
        return this;
    }

    constructor() {
        super(-770, 770, 660, -660, -100, 100);
        this.zoom = 200;
        this.position.z = -1;
    }

    update(width: number, height: number): void {
        const viewSize = height;
        const aspectRatio = width / height;
        this.left = (-aspectRatio * viewSize) / 2;
        this.right = (aspectRatio * viewSize) / 2;
        this.top = viewSize / 2;
        this.bottom = -viewSize / 2;
        this.near = -100;
        this.far = 100;
        this.updateProjectionMatrix();
    }
}