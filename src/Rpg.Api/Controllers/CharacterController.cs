namespace Rpg.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rpg.Core.Dtos.Character;
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
        public async Task<IActionResult> Add(AddCharacterDto toon)
        {
            var response = await _characterService.AddCharacter(toon);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _characterService.GetCharacterById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, UpdateCharacterDto toon)
        {
            var response = await _characterService.UpdateCharacter(id, toon);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return NoContent();
        }
    }
}