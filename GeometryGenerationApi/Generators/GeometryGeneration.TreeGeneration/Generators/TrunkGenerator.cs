using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.TreeGeneration.Interfaces;
using GeometryGeneration.GeometryGeneration.Models;
using GeometryGeneration.TreeGeneration.Utils;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Model;
using Vector = GeometryGeneration.Model.Vector;
using GeometryGeneration.TreeGeneration.Models;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.MathCalculations.Converters;
using GeometryGeneration.MathCalculations.Base;

namespace GeometryGeneration.TreeGeneration.Generators
{
    public class TrunkGenerator : IItemGenerator
    {
        public int Order => -1;

        public void Handle(GeometryModel<TreeGenerationParameters> model)
        {
            var component = new GeometryModelComponent();
            component.Type = TreeModelType.Trunk.ToString();
            //HandleMainPart(component, model.Settings);
            model.Components.Add(component);
        }

        //private void HandleMainPart(GeometryModelComponent component, TreeGenerationParameters settings)
        //{
        //    var dir = settings.Direction.ToVector3D();
        //    var origin = settings.Origin.ToVector3D();

        //    var end = origin.Clone().Add(dir.Clone().Normalize().MultiplyScalar(settings.MainTrunkHeight));

        //    var pBottom = GeometryComponentsUtils.Instance.GenerateCircle(origin.Clone(), dir.Clone(), settings.MainTrunkTkickness, settings.CircleSegmentationParts).ToList();
        //    var pTop = GeometryComponentsUtils.Instance.GenerateCircle(end.Clone(), dir.Clone(), settings.MainTrunkTkickness, settings.CircleSegmentationParts).ToList();
        //    var tree = new Tree
        //    {
        //        Start = origin.Clone(),
        //        End = end.Clone(),
        //        Gravity = dir.Clone(),
        //        Parent = null,
        //        Power = 1,
        //        No = 0,
        //    };
        //    tree.GenerateSubTrees(settings);

        //    if (settings.GeometryItemTypes.Contains(GeometryItemType.Lines))
        //    {
        //        CreateLines(component, pBottom);
        //        CreateLines(component, pTop);
        //        component.Lines.AddRange(tree.ToLines());
        //    }


        //    if (settings.GeometryItemTypes.Contains(GeometryItemType.Triangles))
        //    {
        //        var end = CreateBetweenPointCirlces(component, pBottom, pTop, settings);

        //        var points = tree.SubTrees.Select(x => x.Start);

        //        foreach (var subTree in tree.SubTrees)
        //        {
        //            var pTopTmp = GeometryComponentsUtils.Instance.GenerateCircle(subTree.End, subTree.Dir, 0, settings.CircleSegmentationParts).ToList();
        //            CreateBetweenPointCirlces(component, end, pTopTmp, settings);
        //        }
        //    }
        //}


        //private List<Vector3D> CreateBetweenPointCirlces(GeometryModelComponent component, List<Vector3D> pStart, List<Vector3D> pEnd, TreeGenerationParameters settings)
        //{

        //    var points = CreateBetweenPointCirlces(pStart, pEnd).Select(x => x.Seperate(settings.HeightSegmentationParts, settings.Random).ToList()).ToList();

        //    for (int i = 0; i < points.Count; i++)
        //    {
        //        for (int j = 0; j < points[i].Count - 1; j++)
        //        {
        //            component.Geometry.AddTriangle(
        //                points[i][j].toVector3D(),
        //                points[(i + 1) % points.Count][j].toVector3D(),
        //                points[i][((j + 1) % points[i].Count)].toVector3D(),
        //                new Vector3D(settings.Random.NextDouble(), 0, 0))
        //            );
        //            component.Geometry.AddTriangle(
        //                new Vector(points[(i + 1) % points.Count][j]),
        //                new Vector(points[(i + 1) % points.Count][((j + 1) % points[i].Count)]),
        //                new Vector(points[i][((j + 1) % points[i].Count)]),
        //                new Vector(settings.Random.NextDouble(), 0, 0));
        //        }
        //    }

        //    return points.Select(x => x.Last()).ToList();
        //}


        //private void CreateLines(GeometryModelComponent component, List<Vector3D> points)
        //{
        //    for (int i = 0; i < points.Count; i++)
        //    {

        //        component.Lines.Add(
        //            new Line()
        //            {
        //                Start = new Vector(points[i]),
        //                End = new Vector(points[(i+1) % points.Count]),
        //            }
        //        );
        //    }
        //}

        //private IEnumerable<CircleConnections> CreateBetweenPointCirlces(List<Vector3D> pStart, List<Vector3D> pEnd)
        //{
        //    for (int i = 0; i < pStart.Count; i++)
        //    {
        //        yield return new CircleConnections(pStart[i], pEnd[i]);
        //    }
        //}
    }
}
