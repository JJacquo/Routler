using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Routing;

namespace Routler.Web.Http
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RoutlerRouteAttribute : Attribute, IDirectRouteFactory, IHttpRouteInfoProvider
    {
        public RoutlerRouteAttribute()
        {

        }
         
        public RoutlerRouteAttribute(string template)
        {
            Template = template;
        }

        public RoutlerRouteAttribute(Type t, string name)
        {
            Template =  t.GetRoute(name);
        }

        public string Name { get; set; }
        public int Order { get; set; }
        public string Template { get; set; }

        string IHttpRouteInfoProvider.Name => Name;

        string IHttpRouteInfoProvider.Template => Template;

        int IHttpRouteInfoProvider.Order => Order;

        public RouteEntry CreateRoute(DirectRouteFactoryContext context)
        {
            IDirectRouteBuilder builder = context.CreateBuilder(Template);
            builder.Name = Name;
            builder.Order = Order;
            return builder.Build();
        }
    }
}
