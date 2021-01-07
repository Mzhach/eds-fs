namespace Infrastructure.Database.Entities
{
    public interface IDeleteableEntity
    {
        bool IsDeleted { get; set; }
    }
}
