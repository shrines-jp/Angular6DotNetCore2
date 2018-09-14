using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Angular6DotNetCore2.Models.Repository
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGames();
        Task<Game> GetGame(string id);
        Task Create(Game game);
        Task<bool> Update(Game game);
        Task<bool> Delete(string id);
    }
}
