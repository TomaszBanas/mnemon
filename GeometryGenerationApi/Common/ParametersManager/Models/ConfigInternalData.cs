using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Models
{
    internal class ConfigInternalData<T>
    {
        public string Id { get; set; }
        public Type Type { get; set; }
        public List<T> Attributes { get; set; }
    }
}
