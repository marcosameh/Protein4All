using Microsoft.Extensions.DependencyInjection;

namespace App.UI.Configurations
{
    public static class RegisteredServices
    {
  
        public static IServiceCollection AddRegisteredServices(this IServiceCollection services)
        {
          
                    


            /*use this pattern to register your serivces
             * services.AddScoped(s => new NameOfManager(s.GetService<NameOfContext>(), languageId))
             */
          




            return services;

        }

    }
}
