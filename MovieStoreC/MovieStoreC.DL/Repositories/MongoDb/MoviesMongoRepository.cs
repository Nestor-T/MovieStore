using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStoreC.DL.Interfaces;
using MovieStoreC.Models.Configurations;
using MovieStoreC.Models.DTO;
using System.Runtime.InteropServices;

namespace MovieStoreC.DL.Repositories.MongoDb
{
    internal class MoviesMongoRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly ILogger<MoviesMongoRepository> _logger;

        public MoviesMongoRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<MoviesMongoRepository> logger)
        {
            _logger = logger;

            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);
            _moviesCollection = database.GetCollection<Movie>("MoviesDb");
        }

        public async Task<List<Movie>> GetAll()
        {
            var result = await _moviesCollection.FindAsync(m => true);

            return await result.ToListAsync();
        }

        public async Task<Movie?> GetById(string id)
        {
            var result = await _moviesCollection.FindAsync(m => m.Id == id);

        return  await result.FirstOrDefaultAsync();
        }

        public async Task Add(Movie? movie)
        {
            if (movie == null)
            {
                _logger.LogError("Movie is null");

                return;
            }

            try
            {
                _moviesCollection.InsertOne(movie);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add movie");
            }
        }

        public async Task Update(Movie movie)
        {
            _moviesCollection.ReplaceOne(m => m.Id == movie.Id, movie);
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAterDateTime(DateTime date)
        {
            var result = _moviesCollection.FindAsync(m => m.DateInserted >= date);

            return await result.ToListAsync();
        }
    }
}
