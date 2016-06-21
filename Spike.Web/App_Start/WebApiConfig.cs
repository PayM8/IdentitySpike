
namespace Spike.Web
{
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;

            // Forces browser to return JSON
            formatters.Remove(formatters.XmlFormatter);

           // GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilter());
            //GlobalConfiguration.Configuration.Filters.Add(new BasicAuthorizationFilterAttribute());

            var jsonFormatter = formatters.JsonFormatter;

            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
