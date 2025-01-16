using Moq;
using MovieStoreB.BL.Interfaces;
using MovieStoreB.BL.Services;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.Tests
{
    public class MovieServiceTest
    {

        private readonly Mock<IMovieRepository> _movieRepositoryMock;
        private readonly Mock<IActorRepository> _actorRepositoryMock;

        private List<Movie> _movies = new List<Movie>()
        {
            new Movie()
            {
                Id = "ee8053ae-b95f-4953-a562-4338796e4fb2",
                Title = "Movie 1",
                Year = 2021,
                Actors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Movie()
            {
                Id = "74acae9c-0dec-4ad6-bf2f-6f57b08bd410",
                Title = "Movie 2",
                Year = 2022,
                Actors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        private List<Actor> _actors = new List<Actor>
        {
            new Actor()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Actor 1"
            },
            new Actor()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Actor 2"
            },
            new Actor()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Actor 3"
            },
        };

        public MovieServiceTest()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _actorRepositoryMock = new Mock<IActorRepository>();
        }

        [Fact]
        public void GetMoviesById_ReturnsData()
        {

            var movieId = _movies[0].Id;

            _movieRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>())).Returns((string id) => _movies.FirstOrDefault(x => x.Id == id));

            var movieService = new MovieService(_movieRepositoryMock.Object, _actorRepositoryMock.Object);

            var result = movieService.GetMoviesById(movieId);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetMoviesById_Existing()
        {

            var movieId = "ee8053ae-b95f-4953-a562-4338796e4fb2";

            _movieRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>())).Returns((string id) => _movies.FirstOrDefault(x => x.Id == id));

            var movieService = new MovieService(_movieRepositoryMock.Object, _actorRepositoryMock.Object);
            
            var result = movieService.GetMoviesById(movieId);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetMoviesById_Existing2()
        {

            var movieId = "74acae9c-0dec-4ad6-bf2f-6f57b08bd410";

            _movieRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>())).Returns((string id) => _movies.FirstOrDefault(x => x.Id == id));

            var movieService = new MovieService(_movieRepositoryMock.Object, _actorRepositoryMock.Object);

            var result = movieService.GetMoviesById(movieId);

            Assert.NotNull(result);
        }

    }
}
