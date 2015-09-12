using GreenCredits.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using StructureMap;
using System;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace GreenCredits.API
{
    public class Startup
    {
         private static readonly string connectionString =  ConfigurationManager.AppSettings["connectionString"];
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            ObjectFactory.Initialize(Instances);
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            appBuilder.UseWebApi(config);
        }

        static readonly Action<IInitializationExpression> Instances = builder =>
        {
            builder.For(typeof(IFarmerRepository)).Use(typeof(FarmerRepository))
                .Ctor<string>("connectionString").Is(connectionString);
        };
    }
}