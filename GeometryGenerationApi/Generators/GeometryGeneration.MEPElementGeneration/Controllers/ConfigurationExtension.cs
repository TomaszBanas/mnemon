using GeometryGeneration.Interfaces;
using GeometryGeneration.Interfaces.Routing;
using GeometryGeneration.MEPElementGeneration.Models;
using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MEPElementGeneration.Controllers
{
    public static class ConfigurationExtension
    {
        private static readonly ItemConfigStaticData _itemConfigStaticData = new ItemConfigStaticData
        {
            GenerateEndpoint = "MEPGeneration/Generate",
            ValidateEndpoint = "MEPGeneration/Validate",
        };
        public static void ConfigureMEPEndpoints(this IEndpointManager app)
        {
            app.MapPost(_itemConfigStaticData.GenerateEndpoint, (MEPElementsGenerationParameters data) => new Generator().Generate(data));
            app.MapPost(_itemConfigStaticData.ValidateEndpoint, (MEPElementsGenerationParameters data) => true);
        }
        
        public static void ConfigureMEPModels(this ICacheRegistration app)
        {
            app.Register(typeof(MEPElementsGenerationParameters), _itemConfigStaticData);
        }
    }
}
