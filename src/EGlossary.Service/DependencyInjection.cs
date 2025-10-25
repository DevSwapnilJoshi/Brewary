using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EGlossary.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
        }
    }
}