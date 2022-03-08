using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Model
{
    public class Line
    {

        public string Key { get; set; }
        public Vector Start { get; set; }
        public Vector End { get; set; }
        public double Color { get; set; }
        public double Thickness { get; set; }

        public Line()
        {
            Key = Guid.NewGuid().ToString();
            Start = new Vector();
            End = new Vector();
            Color = 0;
            Thickness = 0.05;
        }
    }
}
