using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular6DotNetCore2.Models;
using Angular6DotNetCore2.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Angular6DotNetCore2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<IEnumerable<Game>> Get()
        {
            return await _gameRepository.GetAllGames();
        }
        // GET: api/Game/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var game = await _gameRepository.GetGame(id);
            if (game == null)
                return new NotFoundResult();
            return new ObjectResult(game);
        }
        // POST: api/Game
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Game game)
        {
            await _gameRepository.Create(game);
            return new OkObjectResult(game);
        }
        // PUT: api/Game/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string id, [FromBody]Game game)
        {
            var gameFromDb = await _gameRepository.GetGame(id);
            if (gameFromDb == null)
                return new NotFoundResult();
            game.Id = gameFromDb.Id;
            await _gameRepository.Update(game);
            return new OkObjectResult(game);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string id)
        {
            var gameFromDb = await _gameRepository.GetGame(id);
            if (gameFromDb == null)
                return new NotFoundResult();
            await _gameRepository.Delete(id);
            return new OkResult();
        }
    }
}