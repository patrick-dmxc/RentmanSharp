using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    public interface IEndpoint
    {
        string Path { get; }
        Filter IncrementFilter { get; }
        Task<IEntity[]> GetCollectionEntity(Filter? filter = null);
        Task<IEntity> GetItemEntity(uint id);
    }
}
