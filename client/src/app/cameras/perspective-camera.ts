import { PerspectiveCamera } from "three";
import { ICamera } from "../interfaces/i-camera";

export class CustomPerspectiveCamera extends PerspectiveCamera implements ICamera {
    public get instance(): PerspectiveCamera {
        return this;
    }

    constructor() {
        super(75, 16/9, 0.1, 1000);
        this.position.z = 6;
        // this.position.y = -2;
        // this.lookAt(0, 0, 0);
    }

    update(width: number, height: number): void {
        this.aspect = width/height;
        this.updateProjectionMatrix();
    }

}