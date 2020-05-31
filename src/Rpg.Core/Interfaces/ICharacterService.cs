namespace Rpg.Core.Interfaces
{
    using Rpg.Core.Models;
    using System.Collections.Generic;

    public interface ICharacterService
    {
        int AddCharacter(Character newCharacter);
        IList<Character> GetAllCharacters();
        Character GetCharacterById(int id);
    }
}
