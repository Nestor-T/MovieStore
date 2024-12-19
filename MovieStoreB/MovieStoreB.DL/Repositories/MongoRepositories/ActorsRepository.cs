using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.DL.Repositories.MongoRepositories
{
    internal class ActorsRepository : IActorRepository
    {
        public Actor? GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
