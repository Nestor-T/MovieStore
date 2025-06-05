
using MessagePack;

namespace MovieStoreB.Models.DTO
{
    [MessagePackObject]
    public record Actor : ICacheItem<string>
    {
        [Key(0)]
        public string Id { get; set; }
        
        [Key(1)]
        public DateTime DateInserted { get; set; }

        [Key(2)]
        public string Bio { get; set; }

        public string GetKey()
        {
            return Id;
        }
    }
}
