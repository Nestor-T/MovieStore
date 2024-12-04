using MovieStoreB.Models.DTO;

namespace MovieStoreB.BL.Interfaces
{
    public interface IActorService
    {
        Actor? GetActorById(int id);
    }
}
