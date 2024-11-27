using Mapster;
using Mapster.Utils;
using MovieStoreB.Models.DTO;
using MovieStoreB.Models.DTO.Requests;

namespace MovieStoreB.MapsterConfig
{
    public class MapsterConfiguratiion
    {
        public static void Configure()
        {
            TypeAdapterConfig<Movie, AddMovieRequest>.NewConfig();
            
        }


    }
}
