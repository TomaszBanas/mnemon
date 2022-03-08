import { ControlArgs } from "../../models/control-args";
import { Matrix4, Mesh, MeshBasicMaterial, Vector3 } from "three";
import { CurrentHighlightModel, HoverHighlightBaseControl } from "../base/hover-highlight-base-control";

export class HoverHighlightOutlineControl extends HoverHighlightBaseControl {
    public createGeometry(data: ControlArgs, current: CurrentHighlightModel, thickness: number): void {
        var a = current.object.clone();
        this.scene.clearScene.add(a);
        const b = current.object.clone();
        const bb = current.hoveredElement.getBoundingBox();
        //scale
        // if(bb) {
        //     b.applyMatrix4(bb.transformationInverted);
        //     const size = bb.localBox.getSize(new Vector3());
        //     const scaleV = new Vector3((size.x+thickness)/size.x, (size.y+thickness)/size.y, (size.z+thickness)/size.z);
        //     b.applyMatrix4(new Matrix4().scale(scaleV));
        //     b.applyMatrix4(bb.transformation);
        //     this.updateMaterialRecurently(b, new MeshBasicMaterial({ color: 0x00ff00 }));
        //     this.scene.scene.add(b);
        // }

        // transform
        if(bb) {
            // b.applyMatrix4(bb.transformationInverted);
            // const size = bb.localBox.getSize(new Vector3());
            // const scaleV = new Vector3((size.x+thickness)/size.x, (size.y+thickness)/size.y, (size.z+thickness)/size.z);
            // b.applyMatrix4(new Matrix4().scale(scaleV));
            // b.applyMatrix4(bb.transformation);
            this.updateMaterialRecurently(b, new MeshBasicMaterial({ color: 0x00ff00 }));
            var t = thickness/2;
            var add = (v: any) => {
                var objTmp = b.clone();
                v.multiplyScalar(t);
                objTmp.applyMatrix4(new Matrix4().makeTranslation(v.x, v.y, v.z));
                this.scene.scene.add(objTmp);
            }
            add(new Vector3(1, 0, 0));
            add(new Vector3(-1, 0, 0));

            add(new Vector3(0, 1, 0));
            add(new Vector3(0, -1, 0));

            add(new Vector3(0, 0, 1));
            add(new Vector3(0, 0, -1));
        }
    }

    private updateMaterialRecurently(object: any, material: MeshBasicMaterial): void
    {
        object.material = material;
        for (const c of object.children) {
            this.updateMaterialRecurently(c, material);
        }
    }
    
}