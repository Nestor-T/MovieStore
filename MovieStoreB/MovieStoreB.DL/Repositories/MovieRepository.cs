using MovieStoreB.DL.DB;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.DTO;

namespace MovieStoreB.DL.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        public List<Movie> GetMovies()
        {
            return StaticData.Movies;
        }

        void AddMovie(Movie movie)
        {
            StaticData.Movies.Add(movie);
        }

        void DeletedMoive(Movie movie)
        {
            StaticData.Movies.Remove(movie);
        }

        public Movie? GetMovieById(int id)
        {
            return StaticData.Movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
