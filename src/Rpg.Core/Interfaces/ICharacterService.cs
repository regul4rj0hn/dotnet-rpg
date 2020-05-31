namespace Rpg.Core.Interfaces
{
    using Rpg.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICharacterService
    {
        Task<int> AddCharacter(Character newCharacter);
        Task<IList<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
    }
}
