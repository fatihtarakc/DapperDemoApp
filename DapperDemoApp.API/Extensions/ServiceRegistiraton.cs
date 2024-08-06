using DapperDemoApp.API.Repositories.Abstract;
using DapperDemoApp.API.Repositories.Concrete;

namespace DapperDemoApp.API.Extensions
{
    public static class ServiceRegistiraton
    {
        public static IServiceCollection AddDapperDemoAppAPIServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}