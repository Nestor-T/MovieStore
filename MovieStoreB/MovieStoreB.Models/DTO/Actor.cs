namespace MovieStoreB.Models.DTO
{
    public record Actor(string Id, string Name) : ICacheItem<string>
    {
        public override string GetKey()
        {
            return Id;
        }
    }
}
