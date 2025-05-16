namespace MovieStoreB.Models.DTO
{
    public interface ICacheItem<T>
    {
        public DateTime DateInserted { get; set; }

        public abstract T GetKey();
    }
}