using GeometryGeneration.BezierCurveGeneration.Models;
using GeometryGeneration.MathCalculations.Base;
using GeometryGeneration.MathCalculations.Converters;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.BezierCurveGeneration
{
    public class Generator
    {
        public GeometryModel<BezierCurveGenerationParameters> Generate(BezierCurveGenerationParameters settings)
        {
            var model = new GeometryModel<BezierCurveGenerationParameters>();
            model.Settings = settings;
            Handle(model);
            return model;
        }


        public void Handle(GeometryModel<BezierCurveGenerationParameters> model)
        {
            var component = new GeometryModelComponent();
            component.Type = "Curve";
            Curve(component, model.Settings);
            model.Components.Add(component);
        }

        private void Curve(GeometryModelComponent component, BezierCurveGenerationParameters settings)
        {

            var curveModel = new BezierCurve3(settings.Points.Where(x => !x.Disabled).Select(x => x.Point.ToVector3D()).ToList());
            Curve(component, curveModel, settings);
        }

        private void Curve(GeometryModelComponent component, Curve curve, BezierCurveGenerationParameters settings)
        {
            var parts = settings.Parts;
            var points = curve.GetPoints(parts);
            for (int i = 0; i <= points.Count-1; i++)
            {
                var m0 = points[i];


                if(settings.ShowLocalMatrix)
                {
                    component.Lines.Add(
                                   new Line()
                                   {
                                       Start = m0.Origin.ToVector(),
                                       End = (m0.Origin.Clone().Add(m0.BaseX.Clone().MultiplyScalar(0.1))).ToVector(),
                                       Color = 0xff0000,
                                       Thickness = 0.0025
                                   }
                               );
                    component.Lines.Add(
                                   new Line()
                                   {
                                       Start = m0.Origin.ToVector(),
                                       End = (m0.Origin.Clone().Add(m0.BaseY.Clone().MultiplyScalar(0.1))).ToVector(),
                                       Color = 0x00ff00,
                                       Thickness = 0.0025
                                   }
                               );
                    component.Lines.Add(
                                   new Line()
                                   {
                                       Start = m0.Origin.ToVector(),
                                       End = (m0.Origin.Clone().Add(m0.BaseZ.Clone().MultiplyScalar(0.1))).ToVector(),
                                       Color = 0x0000ff,
                                       Thickness = 0.0025
                                   }
                               );
                }

                if (i < parts && settings.ShowLine)
                {
                    var m1 = points[i+1];
                    component.Lines.Add(
                               new Line()
                               {
                                   Start = m0.Origin.ToVector(),
                                   End = m1.Origin.ToVector(),
                                   Thickness = 0.005
                               }
                           );
                }

            }
        }

    }
}