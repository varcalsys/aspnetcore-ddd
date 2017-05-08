using Infra.Identity.Data;
using Infra.Identity.Models;
using Infra.Identity.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Identity.Configurations
{
    public class IdentityConfig
    {
        public static void Configure(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }
    }
}
