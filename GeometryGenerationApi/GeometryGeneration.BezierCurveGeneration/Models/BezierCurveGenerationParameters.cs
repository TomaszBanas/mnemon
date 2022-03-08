using GeometryGeneration.Model;
using ParametersManager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.BezierCurveGeneration.Models
{

    [ParameterClass("353a5dd7-b3c2-4e38-8e28-c46ed0dc2f19", "BezierCurveGeneration")]
    public class BezierCurveGenerationParameters
    {

        [ParameterProperty("Points")]
        public List<BezierCurveGenerationPoint> Points { get; set; }
        [ParameterProperty("Parts")]
        public int Parts { get; set; }
        [ParameterProperty("Show local matrix")]
        public bool ShowLocalMatrix { get; set; }
        [ParameterProperty("Show line")]
        public bool ShowLine { get; set; }
    }

    [ParameterClass("353a5dd7-b3c2-4e38-8e28-c46ed0dc2f10", "BezierCurveGenerationPoint")]
    public class BezierCurveGenerationPoint
    {
        [ParameterProperty("Point")]
        public Vector Point { get; set; }
        [ParameterProperty("Disabled")]
        public bool Disabled { get; set; }
    }
}
