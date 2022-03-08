export class Tree
{
    components!: TreeComponent[];
}
export class TreeComponent
{
    componentType!: number;
    geometry!: Geometry;
}
export class Geometry
{
    public normals!: GeometryArray;
    public positions!: GeometryArray;
    public indexes!: GeometryArray;
    public colors!: GeometryArray;
}
export class GeometryArray
{
    public array!: number[];
    public itemSize!: number;
    public count!: number;
}