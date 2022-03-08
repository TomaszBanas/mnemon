import { Box3, ColorRepresentation, Matrix4, Vector3 } from "three";
import { ThreeJsObject } from "../elements/three-js-object";
import { GeometryGenerationUtils } from "./geometry-generation-utils";

export class ElementGenerationUtils
{
    public static generateBB(localBox: Box3, transformation: Matrix4, color: ColorRepresentation): ThreeJsObject  {
        return new ThreeJsObject(GeometryGenerationUtils.generateBB(localBox, transformation, color));
    } 
    public static generateLine(start: Vector3, end: Vector3, thickness: number = 0.01, color: ColorRepresentation = 0x000000): ThreeJsObject {
        return new ThreeJsObject(GeometryGenerationUtils.generateLine(start, end, thickness, color));
    }
    public static generateArrow(headLength: number, headThickness: number, lineLength: number, lineThickness: number, transformation: Matrix4, color: ColorRepresentation): ThreeJsObject {
        return new ThreeJsObject(GeometryGenerationUtils.generateArrow(headLength, headThickness, lineLength, lineThickness, transformation, color));
    }
    public static generatePoint(size: number, position: Vector3, color: ColorRepresentation): ThreeJsObject {
        return new ThreeJsObject(GeometryGenerationUtils.generatePoint(size, position, color));
    }
}