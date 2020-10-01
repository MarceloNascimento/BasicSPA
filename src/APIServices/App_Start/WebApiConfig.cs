

namespace APIServices
{
    using Infra.Mappers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.Cors;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           


            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            var formatters = config.Formatters;
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter());

            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Serviços e configuração da API da Web
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);          

            AutoMapperConfig.RegisterMappings();

           
        }
    }
}
