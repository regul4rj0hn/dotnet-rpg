namespace Rpg.Service
{
    using Microsoft.Extensions.DependencyInjection;
    using Rpg.Core.Interfaces;
    using Rpg.Service.Services;

    public static class Configure
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICharacterService, CharacterService>();
        }
    }
}
