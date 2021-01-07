namespace Infrastructure.Database.Entities
{
    public class ObjectMetadata : BaseEntity
    {
        public long ObjectId { get; set; }
        public virtual Object Object { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
