using System;
using System.Collections.Generic;
using System.Text;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.Model
{
    public class GeometryModelComponent
    {

        public string Type { get; set; }
        public List<Geometry> Geometries { get; set; }
        public List<Line> Lines { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Grid> Grids { get; set; }
        public GeometryModelComponent()
        {
            Type = "Not Defined :(";
            Geometries = new List<Geometry>();
            Lines = new List<Line>();
            Planes = new List<Plane>();
            Grids = new List<Grid>();
        }
    }
}
