using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace WebApi.Configurations
{
    public class OpenApiOptionsConfig : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public OpenApiOptionsConfig(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }


        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateApiInfo(description));
            }
        }

        private static OpenApiInfo CreateApiInfo(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Title = "AspNet Core DDD Sample Project",
                Version = description.ApiVersion.ToString(),
                Description = "AspNet Core DDD API Documentation",
                Contact = new OpenApiContact { Name = "Cleber Varçal", Email = "cleber.varcal@varcalsys.com.br", Url = new Uri("https://varcalsys.com.br") },
                //License = new OpenApiLicense { Name = "", Url = new Uri("") }
            };
        }
    }
}
