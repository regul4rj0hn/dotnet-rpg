namespace Rpg.Service.Mappings
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    
    public static class MapperServiceExtension
    {
        public static void AddMapperServices(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CharacterMap());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}