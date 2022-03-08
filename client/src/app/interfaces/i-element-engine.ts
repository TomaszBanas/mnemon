import { IElement } from "./i-element";
import { IModel } from "./i-model";

export interface IElementEngine<Tmodel extends IModel, Telement extends IElement>
{
    create(model: Tmodel): Telement;
}