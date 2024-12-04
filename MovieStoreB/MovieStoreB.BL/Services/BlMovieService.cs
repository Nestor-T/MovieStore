using MovieStoreB.BL.Interfaces;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.BL.Services
{
    internal class BlMovieService : IBlMovieService

    {
        private readonly IMovieService _movieService;
        private readonly IActorRepository _actorRepository;

        public BlMovieService(IBlMovieService movieService)
        {
            _movieService = _movieService;
            _actorRepository = _actorRepository;
        }

        public List<FullMovieDetails> GetAllMovieDetails()
        {
            var result = new List<FullMovieDetails>();

            var movies = _movieService.GetMovies();
        }

        List<FullMovieDetails> IBlMovieService.GetAllMovieDetails()
        {
            throw new NotImplementedException();
        }
    }
}
