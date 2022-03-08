import { WebGLRenderer } from "three";

export interface IRenderersProvider {
    get(): WebGLRenderer;   
}