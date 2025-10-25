using EGlossary.Service.Middleware;
using Microsoft.AspNetCore.Builder;

namespace EGlossary.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "EasyGroceries e-commerce shop API");
                    setupAction.RoutePrefix = "OpenAPI";
                });
        }
    }
}