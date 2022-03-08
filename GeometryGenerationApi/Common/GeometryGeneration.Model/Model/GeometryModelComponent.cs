using System;
using System.Collections.Generic;
using System.Text;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.Model
{
    public class GeometryModelComponent
    {

        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public List<Line> Lines { get; set; }
        public GeometryModelComponent()
        {
            Geometry = new Geometry();
            Lines = new List<Line>();
        }
    }
}
