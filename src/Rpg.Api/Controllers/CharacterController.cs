namespace Rpg.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rpg.Core.Models;
    using Rpg.Core.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost]
        public IActionResult Add(Character toon)
        {
            
            return Ok(_characterService.AddCharacter(toon));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }
    }
}