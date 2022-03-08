using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Extension
{
    public static class JsonConvertUtils
    {
        public static string SerializeObjectToCamelCase(object model)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(model, serializerSettings);
        }
    }
}
