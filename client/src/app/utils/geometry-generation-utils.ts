import { Box3, BoxGeometry, Color, ColorRepresentation, CylinderGeometry, EdgesGeometry, Group, LineBasicMaterial, LineSegments, Matrix4, Mesh, MeshBasicMaterial, SphereGeometry, Vector3 } from "three";
import { ThreeJsObject } from "../elements/three-js-object";
import { MatrixUtils } from "./matrix-utils";

export class GeometryGenerationUtils
{
    public static generateBB(localBox: Box3, transformation: Matrix4, color: ColorRepresentation): LineSegments {
        const size = localBox.getSize(new Vector3());
        const geometry = new BoxGeometry( size.x, size.y, size.z );
        const edges = new EdgesGeometry( geometry );
        const mesh = new LineSegments( edges, new LineBasicMaterial( { color: color } ) );
        mesh.applyMatrix4(transformation);
        return mesh;
    }
    public static generateLine(start: Vector3, end: Vector3, thickness: number = 0.1, color: ColorRepresentation = 0x000000): Group {
        const colorModel = new Color(color);
        const material = new MeshBasicMaterial({ color: colorModel });
        const group = new Group();
        const dir = start.clone().sub(end);

        const geometryStart = new SphereGeometry( thickness, 32, 16, 0, Math.PI*2, 0, Math.PI/2 );
        const sphereStart = new Mesh( geometryStart, material );
        sphereStart.applyMatrix4(MatrixUtils.create(
            new Vector3(0, 1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(-dir.length()/2, 0, 0)
            ));
        group.add(sphereStart);

        const geometryEnd = new SphereGeometry( thickness, 32, 16, 0, Math.PI*2, 0, Math.PI/2 );
        const sphereEnd = new Mesh( geometryEnd, material );
        sphereEnd.applyMatrix4(MatrixUtils.create(
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, -1),
            new Vector3(dir.length()/2, 0, 0)
            ));
        group.add(sphereEnd);

        const geometry = new CylinderGeometry(thickness, thickness, dir.length(), 32, 1, true, 0, Math.PI*2)
        const mesh = new Mesh(geometry, material);
        mesh.applyMatrix4(MatrixUtils.YtoX.clone());
        const lineMatrix = MatrixUtils.createFromDirection(start, end);
        group.add(mesh);
        group.applyMatrix4(lineMatrix);
        return group;
    }
    public static generateArrow(headLength: number, headThickness: number, lineLength: number, lineThickness: number, transformation: Matrix4, color: ColorRepresentation): Group {
        const arrow = new Group();
        // Head
        const lineGeometry = new CylinderGeometry(lineThickness, lineThickness, lineLength, 64, 1, false, 0, Math.PI*2);
        const lineMaterial = new MeshBasicMaterial({ color: color });
        const line = new Mesh(lineGeometry, lineMaterial);
        line.applyMatrix4(MatrixUtils.YtoX.clone());
        line.applyMatrix4(MatrixUtils.createFromOrigin(new Vector3(lineLength/2, 0, 0)));
        arrow.add(line);
        // Line
        const headGeometry = new CylinderGeometry(0, headThickness, headLength, 64, 1, false, 0, Math.PI*2);
        const headMaterial = new MeshBasicMaterial({ color: color });
        const head = new Mesh(headGeometry, headMaterial);
        head.applyMatrix4(MatrixUtils.YtoX.clone());
        head.applyMatrix4(MatrixUtils.createFromOrigin(new Vector3(lineLength + (headLength/2), 0, 0)));
        arrow.add(head);
        arrow.applyMatrix4(transformation);
        return arrow;
    }
    public static generatePoint(size: number, position: Vector3, color: ColorRepresentation): Mesh {
        const geometry = new SphereGeometry( size, 32, 16 );
        const material = new MeshBasicMaterial( { color: color } );
        const sphere = new Mesh( geometry, material );
        sphere.applyMatrix4(MatrixUtils.createFromOrigin(position));
        return sphere;
    }
}