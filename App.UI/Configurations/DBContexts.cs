using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.UI.Configurations
{
    public static class DBContexts
    {

        public static IServiceCollection AddDBContexts(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Protein4allContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppCore"), builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));    
            });

            return services;
        }
    }
}
