import { ViewerEngine } from "../engine/viewer-engine";
import { IElement } from "../interfaces/i-element";
import { IElementEngine } from "../interfaces/i-element-engine";
import { IModel } from "../interfaces/i-model";
import { IScene } from "../interfaces/i-scene";

export class ViewerArray<Tmodel extends IModel, Telement extends IElement>
{
    public modelMap: Map<string, Tmodel> = new Map<string, Tmodel>();
    public elementMap: Map<string, Telement> = new Map<string, Telement>();
    public scene!: IScene;
    public viewerEngine!: ViewerEngine;
    public elementEngine!: IElementEngine<Tmodel, Telement>;

    constructor(
        scene: IScene,
        viewerEngine: ViewerEngine,
        elementEngine: IElementEngine<Tmodel, Telement>,
    )
    {
        this.scene = scene;
        this.viewerEngine = viewerEngine;
        this.elementEngine = elementEngine;
    }

    public add(model: Tmodel): Telement | undefined
    {
        const data = this.addInternal(model);
        if(data)
            this.viewerEngine.render();
        return data;
    }

    public addMulti(models: Tmodel[]): {model: Tmodel, element: Telement | undefined}[]
    {
        for (const model of models) {
            this.addInternal(model);
        }
        if(models.length > 0)
            this.viewerEngine.render();

        return models.map<{model: Tmodel, element: Telement | undefined}>(x => {
            return {
                model: x,
                element: this.elementMap.get(x.key)
            }
        });
    }

    public update(model: Tmodel): Telement | undefined
    {
        this.remove(model.key);

        const oldElement = this.elementMap.get(model.key);
        if(oldElement) {
            this.scene.removeElement(oldElement);    
        }

        const element = this.elementEngine.create(model);
        if(!element) return undefined;

        this.modelMap.set(model.key, model);
        this.elementMap.set(model.key, element);
        this.scene.addElement(element);
        return element;
    }

    public remove(key: string): void
    {
        this.removeInternal(key);
        this.viewerEngine.render();
    }

    public getModel(key: string): Tmodel | undefined
    {
        return this.modelMap.get(key);
    }

    public getElement(key: string): Telement | undefined
    {
        return this.elementMap.get(key);
    }

    public clear(): void
    {
        this.modelMap.forEach((model, key) => {
            this.removeInternal(key);
        });
        this.viewerEngine.render();
    }


    private removeInternal(key: string): void
    {
        const element = this.elementMap.get(key);
        if(!element) return;
        this.modelMap.delete(key);
        this.elementMap.delete(key);
        this.scene.removeElement(element);
    }

    private addInternal(model: Tmodel): Telement | undefined
    {
        if(this.modelMap.has(model.key))
            return undefined;
        const element = this.elementEngine.create(model);
        if(!element) return undefined;

        this.modelMap.set(model.key, model);
        this.elementMap.set(model.key, element);
        this.scene.addElement(element);
        return element;
    }
}