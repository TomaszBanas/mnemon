using GeometryGeneration.GeneratorBase.Models;
using GeometryGeneration.GeneratorBase.States;
using GeometryGeneration.MathCalculations.Base;
using GeometryGeneration.MathCalculations.Converters;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.MEPElementGeneration.Models;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.MEPElementGeneration
{
    public class Generator
    {
        public GeometryModel<MEPElementsGenerationParameters> Generate(MEPElementsGenerationParameters settings)
        {
            var model = new GeometryModel<MEPElementsGenerationParameters>();
            model.Settings = settings;
            if(settings.MepObjects != null)
            {
                foreach (var item in settings.MepObjects)
                {
                    HandleSingleMEP(model, item);
                }
            }
            return model;
        }


        public void HandleSingleMEP(GeometryModel<MEPElementsGenerationParameters> model, MEPElementParameters item)
        {
            if (item.Hide)
                return;

            var component = new GeometryModelComponent();
            component.Type = "Curve";

            var parts = 20;

            var state = new ConnectionGenerationState(component.Geometry);

            var curve = new BezierCurve3(
                new List<Vector3D>
                {
                    item.StartPoint.ToVector3D(), 
                    item.StartPoint.ToVector3D().Add(item.StartPointDirection.ToVector3D()), 
                    item.EndPoint.ToVector3D().Add(item.EndPointDirection.ToVector3D()), 
                    item.EndPoint.ToVector3D(), 
                });

            var points = curve.GetPoints(parts);

            var radiusOutsideChange = (item.EndPointRadius - item.StartPointRadius) / parts;
            var connectionsOutside = points.Select((p, i) => new Connection(points[i], item.StartPointRadius + (i * radiusOutsideChange), parts)).ToList();
            for (int i = 0; i < connectionsOutside.Count-1; i++)
            {
                state.CreateConnection(connectionsOutside[i], connectionsOutside[i+1]);
            }

            var radiusInsideChange = ((item.EndPointRadius-item.EndPointWallThickness) - (item.StartPointRadius-item.StartPointWallThickness)) / parts;
            var connectionsInside = points.Select((p, i) => new Connection(points[i], (item.StartPointRadius - item.StartPointWallThickness) + (i * radiusInsideChange), parts)).ToList();
            for (int i = 0; i < connectionsInside.Count - 1; i++)
            {
                state.CreateConnection(connectionsInside[i], connectionsInside[i + 1]);
            }
            state.CreateConnection(connectionsInside[0], connectionsOutside[0]);
            state.CreateConnection(connectionsOutside[parts], connectionsInside[parts]);


            model.Components.Add(component);
        }
    }
}