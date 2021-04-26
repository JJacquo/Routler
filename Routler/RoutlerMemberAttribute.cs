using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routler
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RoutlerFieldAttribute : Attribute
    {
        private string routlerClassName;
        private string parameterName;
        private bool defaultRoute;

        public RoutlerFieldAttribute() : this(string.Empty)
        {}

        public RoutlerFieldAttribute(string className, string paramName = null, bool bDefaultRoute = false)
        {
            routlerClassName = className;
            parameterName = paramName;
            defaultRoute = bDefaultRoute;
        }

        public string RoutlerClassName { get { return routlerClassName; } }
        public bool DefaultRoute { get { return defaultRoute; } }
        public string ParameterName { get { return parameterName; } }

    }
}
