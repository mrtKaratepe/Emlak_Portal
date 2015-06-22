using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Configuration;
using Microsoft.Owin.Security;
using Ltd.NA.Emlak.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace Ltd.NA.Emlak.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            
            WebApiConfig.Configure(configuration);

            app.UseWebApi(configuration);
        }
    }
}
