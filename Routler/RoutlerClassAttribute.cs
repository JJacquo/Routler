using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routler
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class RoutlerClassAttribute : Attribute
    {
        private string _uri;
        private string _name;

        public RoutlerClassAttribute() : this(string.Empty, string.Empty)
        { }

        public RoutlerClassAttribute(string uri, string name)
        {
            _uri = uri;
            _name = name;
        }

        public string Name { get { return _name; } }
        public string URI { get { return _uri; } }

    }
}
