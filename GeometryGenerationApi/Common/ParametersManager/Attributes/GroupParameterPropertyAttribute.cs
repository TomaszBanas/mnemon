using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Attributes
{
    public class GroupParameterPropertyAttribute : ParameterPropertyAttribute
    {
        public GroupParameterPropertyAttribute(string name) : base(name) { }
    }
}
