namespace Rpg.Service.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Rpg.Core.Dtos.Character;
    using Rpg.Core.Interfaces;
    using Rpg.Core.Models;
    using Rpg.DbContext;
    using Rpg.DbContext.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CharacterService : ICharacterService
    {
        private readonly RpgContext _context;
        private readonly IMapper _mapper;

        public CharacterService(
            RpgContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(newCharacter);

            await _context.Character.AddAsync(character);
            await _context.SaveChangesAsync();

            var inserted = await _context.Character.FirstOrDefaultAsync(c => c.Id == character.Id);
            response.Data = _mapper.Map<GetCharacterDto>(inserted);

            return response;
        }

        public async Task<ServiceResponse<IList<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<IList<GetCharacterDto>>();

            var characters = await _context.Character.ToListAsync();
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            var toon = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
            response.Data = _mapper.Map<GetCharacterDto>(toon);

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
                var character = _context.Character.FirstOrDefault(c => c.Id == id);

                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;

                _context.Character.Update(character);
                await _context.SaveChangesAsync();

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
                var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);

                response.Data = _mapper.Map<GetCharacterDto>(character);
                response.Message = "Your character was successufully deleted.";

                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
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