using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Models
{
    public class ItemConfig
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ItemConfigProperty> Properties { get; set; }
        public ItemConfigStaticData Data { get; set; }
    }

    public class ItemConfigStaticData
    {
        public string GenerateEndpoint { get; set; }
        public string ValidateEndpoint { get; set; }
    }

    public class ItemConfigProperty
    {
        public string Name { get; set; }
        public string Property { get; set; }
        public string Type { get; set; }
        public ItemConfig SubData { get; set; }
        public string Metadata { get; set; }
    }
}
