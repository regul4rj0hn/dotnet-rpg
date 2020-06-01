namespace Rpg.Service.Mappings
{
    using AutoMapper;
    using Rpg.Core.Dtos.Character;
    using Rpg.DbContext.Models;

    public class CharacterMap : Profile
    {
        public CharacterMap()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}
