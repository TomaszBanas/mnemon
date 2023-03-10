using GeometryGeneration.Model;
using ParametersManager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Test.Models
{
    [JSchema(Title = "Test")]
    //[JSchema("356bf505-b1e3-457c-b72d-c8d93bde81f6", Title = "Test")]
    public class TestGenerationParameters
    {
        [JSchema(Title = "Border points")]
        public List<TestGenerationBorderPointParameter> BorderPoints { get; set; }

        [JSchema(Title = "Origin")]
        public Vector Origin { get; set; }

        [JSchema(Title = "Direction")]
        public Vector Direction { get; set; }

        [JSchema(Title = "Color")]
        public Vector Color { get; set; }

        [JSchema(Title = "Opacity")]
        public double Opacity { get; set; }

        [JSchema(Title = "Debug")]
        public bool Debug { get; set; }
    }

    //[ParameterClass("356bf505-b1e3-457c-b72d-c8d93bde81f7", "TestBorderPoint")]
    [JSchema(Title = "TestBorderPoint")]
    public class TestGenerationBorderPointParameter
    {
        [JSchema(Title = "Point")]
        public Vector Point { get; set; }

    }
}
