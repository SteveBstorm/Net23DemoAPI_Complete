using DAL.Repositories;
using DemoAPI_Complete.DTO;
using DemoAPI_Complete.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI_Complete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository gameService;

        public GameController(IGameRepository gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await gameService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await gameService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]GameDTO game)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await gameService.CreateGame(game.ToDal());
            return Ok();
        }
    }
}

