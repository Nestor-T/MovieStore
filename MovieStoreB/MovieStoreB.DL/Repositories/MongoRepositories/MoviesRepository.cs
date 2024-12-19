using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.Configurations;
using MovieStoreB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.DL.Repositories.MongoRepositories
{
    internal class MoviesRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> _movieCollection;
        private readonly ILogger<MoviesRepository> _logger;

        public MoviesRepository(ILogger<MoviesRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            logger = _logger;

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
        }

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            return _movieCollection.DeleteMovie(string id);
        }

        public List<Movie> GetMovies()
        {
            return _movieCollection.Find(m => true).ToList();
        }

        public Movie? GetMoviesById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
