using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Models
{
    public class Config
    {
        public List<KeyValuePair<string, string>> Types { get; set; }
        public string ConfigUrl { get; set; } = "Parameters/Config";
        public string ItemConfigUrl { get; set; } = "Parameters/ItemConfig";
        public string ItemValidationUrl { get; set; } = "Parameters/ItemValidation";
    }
}
