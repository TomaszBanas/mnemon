using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Model
{
    public class Plane
    {

        public string Key { get; set; }
        public Vector Origin { get; set; }
        public Vector Direction { get; set; }
        public List<Vector> BorderPoints { get; set; }
        public double Color { get; set; }
        public double Opacity { get; set; }

        public Plane(Vector origin, Vector direction, string key = null, List<Vector> borderPoints = null, double color = 0xffffff, double opacity = 1)
        {
            Origin = origin;
            Direction = direction;
            Key = key ?? Guid.NewGuid().ToString();
            BorderPoints = borderPoints ?? new List<Vector>();
            Color = color;
            Opacity = opacity;
        }
    }
}
