using FinalOpt.Infraestructure.Interfaces;
using FinalOpt.Infraestructure.Services;

namespace FinalOpt
{
    public static class IoC
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpService, HttpService>();
            services.AddTransient<ITablingService, TablingService>();
            services.AddTransient<IStorageService, StorageService>();
        }
    }
}
