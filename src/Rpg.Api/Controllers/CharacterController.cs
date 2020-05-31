namespace Rpg.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rpg.Models.Models;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static IList<Character> characters = new List<Character> {
            new Character(),
            new Character { Id= 1, Name = "Sam"}
        };

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        [HttpPost]
        public IActionResult Add(Character toon)
        {
            characters.Add(toon);
            return Ok(characters);
        }
    }
}