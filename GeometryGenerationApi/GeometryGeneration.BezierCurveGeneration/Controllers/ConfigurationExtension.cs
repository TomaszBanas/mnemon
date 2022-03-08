using GeometryGeneration.BezierCurveGeneration.Models;
using GeometryGeneration.Interfaces;
using GeometryGeneration.Interfaces.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.BezierCurveGeneration.Controllers
{
    public static class ConfigurationExtension
    {
        private static readonly ItemConfigStaticData _itemConfigStaticData = new ItemConfigStaticData
        {
            GenerateEndpoint = "BezierCurveGeneration/Generate",
            ValidateEndpoint = "BezierCurveGeneration/Validate",
        };
        public static void ConfigureBazierCurveEndpoints(this IEndpointManager app)
        {
            app.MapPost(_itemConfigStaticData.GenerateEndpoint, (BezierCurveGenerationParameters data) => new Generator().Generate(data));
            app.MapPost(_itemConfigStaticData.ValidateEndpoint, (BezierCurveGenerationParameters data) => true);
        }
        
        public static void ConfigureBazierCurveModels(this ICacheRegistration app)
        {
            app.Register(typeof(BezierCurveGenerationParameters), _itemConfigStaticData);
        }
    }
}
