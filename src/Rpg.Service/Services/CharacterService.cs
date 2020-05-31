namespace Rpg.Service.Services
{
    using Rpg.Core.Interfaces;
    using Rpg.Core.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterService : ICharacterService
    {        
        private static IList<Character> characters = new List<Character> {
            new Character(),
            new Character { Id= 1, Name = "Sam"}
        };

        public int AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return newCharacter.Id;
        }
        public IList<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}