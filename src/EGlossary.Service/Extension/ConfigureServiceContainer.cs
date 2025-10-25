using AutoMapper;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence;
using EGlossary.Persistence.Reposistory;
using EGlossary.Service.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EGlossary.Service.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
        }

        public static void AddDbContext(this IServiceCollection serviceCollection)

        {
            serviceCollection.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("ImMemoryDb"));
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<InMemoryDbContext>()
                .AddScoped<IProductReposistory, ProductReposistory>();
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "EasyGroceries e-commerce shop",
                        Version = "1",
                        Description = "Through this API you can access EasyGroceries e-commerce shop",
                    });
            });
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}