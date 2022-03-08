using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.TreeGeneration.Utils;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Model;
using GeometryGeneration.Model.Extension;
using Vector = GeometryGeneration.Model.Vector;
using GeometryGeneration.TreeGeneration.Models;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.MathCalculations.Converters;

namespace GeometryGeneration.GeometryGeneration.Models
{
    public class Tree
    {
        public Vector3D Start { get; set; }
        public Vector3D End { get; set; }
        public Vector3D Gravity { get; set; }
        public Tree Parent { get; set; }
        public List<Tree> SubTrees { get; set; }
        public int Power { get; set; }
        public int No { get; set; }
        public Vector3D Dir => End.Clone().Substract(Start).Normalize();
        public double Length => End.Clone().Substract(Start).Length();

        public void GenerateSubTrees(TreeGenerationParameters parameters)
        {
            SubTrees = new List<Tree>();
            if (Power < 1)
                return;
            
            if (No > parameters.MaxBranches)
                return;

            var transformation = GeometryComponentsUtils.Instance.GenerateMatrix(Dir);

            var max = Parent != null ? Parent.SubTrees.Count : 4;
            var noOfSubs = parameters.Random.Next(1, max+1);

            //for (int i = 0; i < 1000; i++)
            //{
            //    var t = parameters.Random.Next(1, 3);
            //    if(t != 1)
            //    {
            //        if (t == 3)
            //            break;
            //    }
            //}

            for (int i = 0; i < noOfSubs; i++)
            {
                var newLength = parameters.Random.NextSingle(Length / 2, Length);
                var newDir = Gravity;
                newDir = GeometryComponentsUtils.Instance.ApplyAxisAngle(newDir, transformation.BaseY, parameters.Random.NextSingle(-parameters.MaxBranchAngle, parameters.MaxBranchAngle));
                newDir = GeometryComponentsUtils.Instance.ApplyAxisAngle(newDir, transformation.BaseZ, parameters.Random.NextSingle(-parameters.MaxBranchAngle, parameters.MaxBranchAngle));

                //newDir.X += (float)(i+1)*3;
                //newDir.Y += (float)i*3;
                //newDir.Z += (float)i*3;
                newDir.Normalize();
                newDir.MultiplyScalar(newLength);
                var sub = new Tree
                {
                    Start = End.Clone(),
                    End = End.Clone().Add(newDir),
                    Gravity = Gravity,
                    Parent = this,
                    Power = Power - 1,
                    No = No + 1,
                };
                SubTrees.Add(sub);
            }

            foreach (var item in SubTrees)
            {
                item.GenerateSubTrees(parameters);
            }
        }


        public List<Line> ToLines()
        {
            var result = new List<Line>();
            result.Add(
            new Line()
            {
                Start = Start.ToVector(),
                End = End.ToVector(),
            });
            result.AddRange(SubTrees.SelectMany(x => x.ToLines()));
            return result;
        }
    }
}
