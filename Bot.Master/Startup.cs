using System;
using Owin;
using System.Web.Http;
using System.Net.Http;
using System.Linq;

namespace Bot.Master
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();
           
            config.Routes.MapHttpRoute(
                name: "createUserApi",
                routeTemplate: "api/{controller}/{action}"               
                );
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            appBuilder.UseWebApi(config);
        }
    }
}
