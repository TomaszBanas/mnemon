using System;
using System.Collections.Generic;
using System.Text;
using GeometryGeneration.Model.Interfaces;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.Model
{
    public class Geometry : IGeometry
    {
        public string Key { get; set; }
        public GeometryArray Normals {  get; set; }
        public GeometryArray Vertices {  get; set; }
        public GeometryArray Indexes { get; set; }
        public GeometryArray Colors { get; set; }

        public Geometry()
        {
            Key = Guid.NewGuid().ToString();
            Normals = new GeometryArray(3);
            Vertices = new GeometryArray(3);
            Indexes = new GeometryArray(1);
            Colors = new GeometryArray(3);
        }


        public void AddTriangle(Vector p1, Vector p2, Vector p3)
        {
            AddTriangle(p1, p2, p3, new Vector(0, 0, 0));
        }

        public void AddTriangle(Vector p1, Vector p2, Vector p3, Vector color)
        {
            var verticiesCount = Vertices.Count;
            Indexes.Array.Add(verticiesCount + 0);
            Indexes.Array.Add(verticiesCount + 1);
            Indexes.Array.Add(verticiesCount + 2);
            Indexes.Count += 1;

            Vertices.Array.Add(p1.X);
            Vertices.Array.Add(p1.Y);
            Vertices.Array.Add(p1.Z);

            Vertices.Array.Add(p2.X);
            Vertices.Array.Add(p2.Y);
            Vertices.Array.Add(p2.Z);

            Vertices.Array.Add(p3.X);
            Vertices.Array.Add(p3.Y);
            Vertices.Array.Add(p3.Z);
            Vertices.Count += 3;


            Colors.Array.Add(color.X);
            Colors.Array.Add(color.Y);
            Colors.Array.Add(color.Z);
            Colors.Array.Add(color.X);
            Colors.Array.Add(color.Y);
            Colors.Array.Add(color.Z);
            Colors.Array.Add(color.X);
            Colors.Array.Add(color.Y);
            Colors.Array.Add(color.Z);
            Colors.Count += 3;
        }


        public void Merge(Geometry g)
        {
            for (int i = 0; i < g.Vertices.Array.Count; i+=9)
            {
                var p1 = new Vector(g.Vertices.Array[i+0], g.Vertices.Array[i+1], g.Vertices.Array[i+2]);
                var p2 = new Vector(g.Vertices.Array[i+3], g.Vertices.Array[i+4], g.Vertices.Array[i+5]);
                var p3 = new Vector(g.Vertices.Array[i+6], g.Vertices.Array[i+7], g.Vertices.Array[i+8]);
                var color = new Vector(g.Colors.Array[i+0], g.Colors.Array[i+1], g.Colors.Array[i+2]);
                AddTriangle(p1, p2, p3, color);
            }
        }
    }
}
