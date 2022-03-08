using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Attributes
{
    public class ParameterPropertyAttribute : Attribute
    {
        public string Name { get; set; }
        public ParameterPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
