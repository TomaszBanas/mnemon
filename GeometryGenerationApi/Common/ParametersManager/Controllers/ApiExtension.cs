using GeometryGeneration.Interfaces.Routing;
using ParametersManager.Managers;
using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Controllers
{
    public static class ApiExtension
    {
        public static void ConfigurePropertiesEndpoints(this IEndpointManager app)
        {
            var config = new Config();
            app.MapGet(config.ConfigUrl, () => ConfigCache.Instance.GetConfig());
            app.MapGet(config.ItemConfigUrl, (string id) => ConfigCache.Instance.GetConfig(id));
            app.MapGet(config.ItemValidationUrl, (string id) => false);
        }
    }
}
