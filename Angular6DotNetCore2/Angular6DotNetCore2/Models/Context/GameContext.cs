using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Angular6DotNetCore2.Models.Context
{
    public class GameContext : IGameContext
    {
        private readonly IMongoDatabase _db = null;
        public GameContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Game> Games => _db.GetCollection<Game>("Games");
    }
}
