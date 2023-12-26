using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
