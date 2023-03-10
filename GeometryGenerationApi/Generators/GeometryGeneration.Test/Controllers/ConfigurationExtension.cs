using GeometryGeneration.Interfaces;
using GeometryGeneration.Interfaces.Routing;
using GeometryGeneration.Test.Models;
using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Test.Controllers
{
    public static class ConfigurationExtension
    {
        private static readonly ItemConfigStaticData _itemConfigStaticData = new ItemConfigStaticData
        {
            GenerateEndpoint = "TestGeneration/Generate",
            ValidateEndpoint = "TestGeneration/Validate",
        };
        public static void ConfigureTestEndpoints(this IEndpointManager app)
        {
            app.MapPost(_itemConfigStaticData.GenerateEndpoint, (TestGenerationParameters data) => new Generator().Generate(data));
            app.MapPost(_itemConfigStaticData.ValidateEndpoint, (TestGenerationParameters data) => true);
        }

        public static void ConfigureTestModels(this ICacheRegistration app)
        {
            app.Register(typeof(TestGenerationParameters), _itemConfigStaticData);
        }
    }
}
