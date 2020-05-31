namespace Rpg.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rpg.Core.Models;
    using Rpg.Core.Interfaces;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> Add(Character toon)
        {
            
            return Ok(await _characterService.AddCharacter(toon));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
    }
}