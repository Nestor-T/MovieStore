using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using MovieStoreC.DL.Interfaces;

namespace MovieStoreC.Models.DTO.Cache
{
  
    public class MongoCacheDistributor : BackgroundService
    {
        //full load method - read entire collection
        //diffload - read only new or updated records()

        private readonly IMovieRepository _movieRepository;

        public override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var lastExecuted = DateTime.UtcNow;
            var result = _movieRepository.GetAll();

            foreach (var movie in result) {
                Console.WriteLine(movie.title);
            }

            while (stoppingToken.IsCancellationRequested) {
                await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);

                var updatedmovies = await _movieRepository.GetMoviesAfterDateTime(lastExecuted);

                lastExecuted = DateTime.UtcNow;
                foreach (var movie in updatedmovies) {
                    if (movie != null) {
                        Console.WriteLine(movie.title);
                    }
                }
            }
            
        }

    }
}