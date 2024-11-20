using MovieStoreB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.BL.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
    }
}
