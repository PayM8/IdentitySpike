
namespace Spike.Web
{
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Spike.Security.Authentication.BasicAuth.Rest;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;

            // Forces browser to return JSON
            formatters.Remove(formatters.XmlFormatter);


            var jsonFormatter = formatters.JsonFormatter;

            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            GlobalConfiguration.Configuration.Filters.Add(new BasicAuthentication());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
