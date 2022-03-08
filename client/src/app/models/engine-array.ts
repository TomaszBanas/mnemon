import { generateUUID } from "three/src/math/MathUtils";
import { IElement } from "../interfaces/i-element";
import { IModel } from "../interfaces/i-model";
import { ViewerArray } from "./viewer-array";

export class EngineArray<Tmodel extends IModel, Telement extends IElement>
{
    public models!: Tmodel[];
    public viewerArray!: ViewerArray<Tmodel, Telement>;

    constructor(
        models: Tmodel[],
        viewerArray: ViewerArray<Tmodel, Telement>
    )
    {
        this.models = models;
        this.viewerArray = viewerArray;
        var elements = this.viewerArray.addMulti(this.models);
        elements.forEach(d => {
            if(d.element) d.element.removeByKey = this.remove.bind(this);
        })
    }

    public has(model: Tmodel): boolean
    {
        return this.models.some(x => x.key === model.key);
    }

    public add(model: Tmodel): void
    {
        if(this.has(model))
            throw "model already exist";

        if(!model.key)
            model.key = generateUUID();

        this.models.push(model);
        const element = this.viewerArray.add(model);
        if(element) element.removeByKey = this.remove.bind(this);
    }

    public addMulti(models: Tmodel[]): void
    {
        const data = models.filter(x => !this.has(x));
        for (const d of data) {
            if(!d.key)
                d.key = generateUUID();
            this.models.push(d);
        }
        var elements = this.viewerArray.addMulti(data);
        elements.forEach(d => {
            if(d.element) d.element.removeByKey = this.remove.bind(this);
        })
    }

    public update(model: Tmodel): void
    {
        if(!this.has(model))
            throw "model do not exist";

        const index = this.models.findIndex(x => x.key === model.key);
        this.models[index] = model;
        const element = this.viewerArray.update(model);
        if(element) element.removeByKey = this.remove.bind(this);
    }

    public remove(key: string): void
    {
        const index = this.models.findIndex(x => x.key === key);
        if(index < 0)
            throw "model do not exist";

        this.models.splice(index, 1);
        this.viewerArray.remove(key);
    }

    public clear(): void
    {
        while(this.models.length > 0)
        {
            this.models.splice(0, 1);
        }
        this.viewerArray.clear();
    }
}