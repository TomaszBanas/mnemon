using GeometryGeneration.Model;
using ParametersManager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeometryGeneration.MEPElementGeneration.Models
{

    [ParameterClass("e8628b6b-10de-424b-9429-5fa081fde600", "MEP Elements")]
    public class MEPElementsGenerationParameters
    {

        [ParameterProperty("MEP Objects")]
        public List<MEPElementParameters> MepObjects { get; set; }

        //[GroupParameterProperty("Test")]
        //public MEPElementParameters Test { get; set; }

        [ParameterProperty("Debug")]
        public bool Debug { get; set; }
    }

    [ParameterClass("8aafaf82-d6e9-4284-8458-b637515bc025", "MEPElementParameters")]
    public class MEPElementParameters
    {
        [ParameterProperty("Start point")]
        //[JsonPropertyName("1")]
        public Vector StartPoint { get; set; }

        [ParameterProperty("Start point direction")]
        public Vector StartPointDirection { get; set; }

        [ParameterProperty("Start point radius")]
        public double StartPointRadius { get; set; }

        [ParameterProperty("Start point wall thickness")]
        public double StartPointWallThickness { get; set; }

        [ParameterProperty("End point")]
        public Vector EndPoint { get; set; }

        [ParameterProperty("End point direction")]
        public Vector EndPointDirection { get; set; }

        [ParameterProperty("End point radius")]
        public double EndPointRadius { get; set; }

        [ParameterProperty("End point wall thickness")]
        public double EndPointWallThickness { get; set; }
        [ParameterProperty("Hide")]
        public bool Hide { get; set; }

    }
}
