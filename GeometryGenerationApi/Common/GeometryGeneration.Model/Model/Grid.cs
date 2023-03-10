using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Model
{
    public class Grid
    {
        public string Key { get; set; }
        public Vector BaseX { get; set; }
        public Vector BaseY { get; set; }
        public Vector BaseZ { get; set; }
        public Vector Origin { get; set; }

        public Grid()
        {
            Key = Guid.NewGuid().ToString();
            BaseX = new Vector(1, 0, 0);
            BaseY = new Vector(0, 1, 0);
            BaseZ = new Vector(0, 0, 1);
            Origin = new Vector(0, 0, 0);
        }
    }
}
