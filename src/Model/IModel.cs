namespace SiteCreator.Entities
{
    public interface WithId<TId>
    {
        TId Id { get; set; }
    }
}
