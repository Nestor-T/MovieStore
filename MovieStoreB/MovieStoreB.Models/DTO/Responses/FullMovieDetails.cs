using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreB.Models.DTO;

namespace MovieStoreB.Models.DTO.Responses
{
    public class FullMovieDetails
    {
        public Movie Movie { get; set; }

        public List<Actor> Actors { get; set; }

    }
}
