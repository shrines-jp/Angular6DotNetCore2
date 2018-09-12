using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular6DotNetCore2.Models.Context;
using MongoDB.Driver;

namespace Angular6DotNetCore2.Models.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IGameContext _context;
        public GameRepository(IGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            var document = await _context.Games.Find(_ => true).ToListAsync();
            return document;
        }

        public Task<Game> GetGame(string name)
        {
            FilterDefinition<Game> filter = Builders<Game>.Filter.Eq(m => m.Name, name);
            return _context.Games.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Create(Game game)
        {
            await _context.Games.InsertOneAsync(game);
        }

        public async Task<bool> Update(Game game)
        {
            ReplaceOneResult updateResult = await _context.Games.ReplaceOneAsync(filter: g => g.Id == game.Id,replacement: game);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Game> filter = Builders<Game>.Filter.Eq(m => m.Name, name);
            DeleteResult deleteResult = await _context.Games.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
