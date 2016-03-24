using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace LekTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var binder = new DateTimeModelBinder("yyyy-MM-dd HH:mm:ss");
            ModelBinders.Binders.Add(typeof(DateTime), binder);
        }
    }
}
