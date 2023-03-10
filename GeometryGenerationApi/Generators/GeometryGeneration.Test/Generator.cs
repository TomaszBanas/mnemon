using GeometryGeneration.MathCalculations.Converters;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Model;
using GeometryGeneration.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Test
{
    public class Generator
    {
        public GeometryModel<TestGenerationParameters> Generate(TestGenerationParameters settings)
        {
            var model = new GeometryModel<TestGenerationParameters>();
            model.Settings = settings;

            var plane = new Plane(
                settings.Origin, 
                settings.Direction)
            {
                BorderPoints = settings.BorderPoints.Select(x => x.Point).ToList(),
                Color = settings.Color.ToHex(),
                Opacity = settings.Opacity,
            };
            var component = new GeometryModelComponent();
            component.Planes.Add(plane);
            model.Components.Add(component);
            return model;
        }
    }
}
