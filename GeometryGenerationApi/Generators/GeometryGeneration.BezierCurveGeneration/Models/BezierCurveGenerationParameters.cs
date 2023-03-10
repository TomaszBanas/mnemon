using GeometryGeneration.Model;
using ParametersManager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.BezierCurveGeneration.Models
{

    //[ParameterClass("353a5dd7-b3c2-4e38-8e28-c46ed0dc2f19", "BezierCurveGeneration")]
    [JSchema(Title = "BezierCurveGeneration")]
    public class BezierCurveGenerationParameters
    {

        [JSchema(Title = "Points")]
        public List<BezierCurveGenerationPoint> Points { get; set; }
        [JSchema(Title = "Parts")]
        public int Parts { get; set; }
        [JSchema(Title = "Show local matrix")]
        public bool ShowLocalMatrix { get; set; }
        [JSchema(Title = "Show line")]
        public bool ShowLine { get; set; }
    }

    //[ParameterClass("353a5dd7-b3c2-4e38-8e28-c46ed0dc2f10", "BezierCurveGenerationPoint")]
    [JSchema(Title = "BezierCurveGenerationPoint")]
    public class BezierCurveGenerationPoint
    {
        [JSchema(Title = "Point")]
        public Vector Point { get; set; }
        [JSchema(Title = "Disabled")]
        public bool Disabled { get; set; }
    }
}
