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
    [ParameterClass("353a5dd7-b3c2-4e38-8e28-c46ed0dc2f18", "TreeGeneration")]
    public class TreeGenerationParameters : IGeometryModelSettings
    {
        [ParameterProperty("Seed")]
        public int Seed { get; set; }
        [ParameterProperty("Components to generate")]
        public List<TreeModelType> ComponentsToGenerate { get; set; }
        [ParameterProperty("Direction")]
        public Vector Direction { get; set; }
        [ParameterProperty("Origin")]
        public Vector Origin { get; set; }
        [ParameterProperty("Geometry items")]
        public List<GeometryItemType> GeometryItemTypes { get; set; }

        [ParameterProperty("Number of branches")]
        public Range NumberOfBranchesRange { get; set; }
        
        [ParameterProperty("Circle segmentation parts")]
        public Range CircleSegmentationPartsRange { get; set; }
        
        [ParameterProperty("Height segmentation parts")]
        public Range HeightSegmentationPartsRange { get; set; }
        [ParameterProperty("Max branches")]
        public Range MaxBranchesRange { get; set; }
        [ParameterProperty("Height")]
        public Range HeightRange { get; set; }
        [ParameterProperty("Main trunk tkickness")]
        public double MainTrunkTkickness { get; set; }
        [ParameterProperty("Max branch angle")]
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
