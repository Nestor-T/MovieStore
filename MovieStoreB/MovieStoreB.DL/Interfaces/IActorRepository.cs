using MovieStoreB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.DL.Interfaces
{
    public interface IActorRepository
    {
        Actor GetById(int id);

    }
}
