using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class SwaggerExtensions
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services, string title, string version)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(version, new OpenApiInfo
            {
                Title = title,
                Version = version,
            });
        });

        return services;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "We need this to differentiate from the base Swagger method")]
    public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger();

        return app;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "We need this to differentiate from the base Swagger method")]
    public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwaggerUI();

        return app;
    }

    public static void MapRootToSwaggerUI(this IEndpointRouteBuilder endpoints, string routePrefix = "swagger/index.html")
    {
        endpoints.MapGet("/", context =>
        {
            context.Response.Redirect(routePrefix);
            return Task.CompletedTask;
        });
    }
}
