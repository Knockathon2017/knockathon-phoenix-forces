using GreenCredits.DAL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GreenCredits.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly string connectionString = ConfigurationManager.AppSettings["connectionString"];

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ObjectFactory.Initialize(Instances);

        }

        static readonly Action<IInitializationExpression> Instances = builder =>
        {
            builder.For(typeof(IFarmerRepository)).Use(typeof(FarmerRepository))
                .Ctor<string>("connectionString").Is(connectionString);
        };
    }
}
