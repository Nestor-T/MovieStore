using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreB.Models.DTO.Responses;
using MovieStoreB.BL.Interfaces;

namespace MovieStoreB.BL.Interfaces
{
    internal interface IBlMovieService
    {
        List<FullMovieDetails> GetAllMovieDetails();
            

    }
}
