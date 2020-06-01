namespace Rpg.Service
{
    using Microsoft.Extensions.DependencyInjection;
    using Rpg.Core.Interfaces;
    using Rpg.DbContext;
    using Rpg.Service.Mappings;
    using Rpg.Service.Services;

    public static class Configure
    {
        public static void AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddMapperServices();
            
            services.AddDataAccessServices(connectionString);

            services.AddScoped<ICharacterService, CharacterService>();
        }
    }
}
