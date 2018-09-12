using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Angular6DotNetCore2.Models.Context
{
    public interface IGameContext
    {
        IMongoCollection<Game> Games { get; }
    }
}
