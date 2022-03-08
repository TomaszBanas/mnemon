using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Attributes
{
    public class ParameterClassAttribute : Attribute
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ParameterClassAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
