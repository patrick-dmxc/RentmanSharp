using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    public interface IEndpoint
    {
        string Path { get; }
        Task<IEntity[]> GetCollectionEntity(Pagination? pagination = null);
        Task<IEntity> GetItemEntity(uint id);
    }
}
