namespace Rpg.Service.Services
{
    using AutoMapper;
    using Rpg.Core.Dtos.Character;
    using Rpg.Core.Interfaces;
    using Rpg.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CharacterService : ICharacterService
    {        
        private static IList<Character> characters = new List<Character> {
            new Character(),
            new Character { Id= 1, Name = "Sam"}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(newCharacter);

            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).FirstOrDefault(c => c.Name == newCharacter.Name);

            return response;
        }
        public async Task<ServiceResponse<IList<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<IList<GetCharacterDto>>();

            response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            response.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));

            if (response.Data == null) 
            {
                response.Success = false;
                response.Message = "Character not found.";
            }

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharacterDto updatedCharacter)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {
                var character = characters.FirstOrDefault(c => c.Id == id);

                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> DeleteCharacter(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {
                var character = characters.First(c => c.Id == id);
                response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).FirstOrDefault(c => c.Id == id);
                response.Message = "Your character was successufully deleted.";
                characters.Remove(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}