using GeometryGeneration.Model.Interfaces;
using GeometryGeneration.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model
{
    public class GeometryModel<T>
    {
        public List<GeometryModelComponent> Components { get; set; }
        public T Settings { get; set; }
        public GeometryModel()
        {
            Components = new List<GeometryModelComponent>()
            {
                new GeometryModelComponent()
                {
                    Type = "Static Objects",
                    Grids = new List<Grid>
                    {
                        new Grid()
                    }
                }
            };
            Settings = default(T);
        }
    }
}
