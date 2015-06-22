using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Ltd.NA.Emlak.Api
{
    public class WebApiConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            // Attribute routing.
            configuration.MapHttpAttributeRoutes();

            // Convention-based routing.
            configuration.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

            JsonMediaTypeFormatter jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }
    }
}