namespace Rpg.DbContext
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class Configure
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RpgContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Rpg.Api")));
        }
    }
}
