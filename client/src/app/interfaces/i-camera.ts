import { Camera } from "three";

export interface ICamera {
    instance: Camera;
    update(width: number, height: number): void;
}