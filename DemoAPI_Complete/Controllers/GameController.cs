using DAL.Repositories;
using DemoAPI_Complete.DTO;
using DemoAPI_Complete.Hubs;
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
        private readonly GameHub _gameHub;

        public GameController(IGameRepository gameService, GameHub gameHub)
        {
            this.gameService = gameService;
            _gameHub = gameHub;
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

            gameService.CreateGame(game.ToDal());
            await _gameHub.NotifyNewGame();
            return Ok();
        }
    }
}

