using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence.Reposistory;
using EGlossary.Service;
using EGlossary.Service.Extension;
using EGlossary.Service.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EGlossary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                 options.WithOrigins("http://localhost:3000")
                 .AllowAnyHeader()
                 .AllowAnyMethod());

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.ConfigureSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddController();

            services.AddDbContext();

            services.AddAutoMapper();

            services.AddScopedServices();
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddSwaggerOpenAPI();

            services.AddServiceLayer();

            services.AddVersion();
            services.AddValidatorsFromAssemblyContaining<OrderValidator>();
            services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            services.AddTransient<IProductReposistory, ProductReposistory>();

            services.AddTransient<IOrderReposistory, OrderReposistory>();

            services.AddTransient<ICustomerReposistory, CustomerReposistory>();
            services.AddTransient<ICategoryReposistory, CategoryReposistory>();
            services.AddTransient<IBreweryReposistory, BreweryReposistory>();
        }
    }
}