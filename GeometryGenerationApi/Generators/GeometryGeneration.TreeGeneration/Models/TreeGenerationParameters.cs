using GeometryGeneration.Model;
using GeometryGeneration.Model.Interfaces;
using ParametersManager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.Model.Extension;
using Range = GeometryGeneration.Model.Model.Range;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.TreeGeneration.Models
{
    //[ParameterClass("353a5dd7-b3c2-4e38-8e28-c46ed0dc2f18", "TreeGeneration")]
    [JSchema(Title = "TreeGeneration")]
    public class TreeGenerationParameters : IGeometryModelSettings
    {
        [JSchema(Title = "Seed")]
        public int Seed { get; set; }
        [JSchema(Title = "Components to generate")]
        public List<TreeModelType> ComponentsToGenerate { get; set; }
        [JSchema(Title = "Direction")]
        public Vector Direction { get; set; }
        [JSchema(Title = "Origin")]
        public Vector Origin { get; set; }
        [JSchema(Title = "Geometry items")]
        public List<GeometryItemType> GeometryItemTypes { get; set; }

        [JSchema(Title = "Number of branches")]
        public Range NumberOfBranchesRange { get; set; }
        
        [JSchema(Title = "Circle segmentation parts")]
        public Range CircleSegmentationPartsRange { get; set; }
        
        [JSchema(Title = "Height segmentation parts")]
        public Range HeightSegmentationPartsRange { get; set; }
        [JSchema(Title = "Max branches")]
        public Range MaxBranchesRange { get; set; }
        [JSchema(Title = "Height")]
        public Range HeightRange { get; set; }
        [JSchema(Title = "Main trunk tkickness")]
        public double MainTrunkTkickness { get; set; }
        [JSchema(Title = "Max branch angle")]
        public double MaxBranchAngle { get; set; }


        // generated
        internal Random Random { get; set; }
        internal int NumberOfBranches { get; set; }
        internal int Height { get; set; }
        internal int CircleSegmentationParts { get; set; }
        internal int HeightSegmentationParts { get; set; }
        internal int MaxBranches { get; set; }
        internal double MainTrunkHeight => Height / 3;


        public void UpdateInternalValues()
        {
            Random = new Random(Seed);
            NumberOfBranches = Random.Next(NumberOfBranchesRange);
            CircleSegmentationParts = Random.Next(CircleSegmentationPartsRange);
            HeightSegmentationParts = Random.Next(HeightSegmentationPartsRange);
            MaxBranches = Random.Next(MaxBranchesRange);
            Height = Random.Next(HeightRange);
        }
    }
}
