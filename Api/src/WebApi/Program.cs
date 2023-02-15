using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NucleoCompartilhado.DomainEvents.Events;
using System.Threading.Tasks;
using Utilitarios.IoC;
using WebApi.Configurations;

namespace Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization();
            builder.Services.AddHttpContextAccessor();

            builder.Services
                .AddApiConfiguration()
                .AddSwaggerConfig();
            IoCConfig.RegisterServices(builder.Services);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseOpenApiConfig(provider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var accessor = app.Services.GetService<IHttpContextAccessor>();
            DomainEvent.ContainerAccessor = () => accessor.HttpContext?.RequestServices;

            await app.RunAsync();
        }
    }
}
