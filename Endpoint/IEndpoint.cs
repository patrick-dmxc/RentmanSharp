using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    public interface IEndpoint
    {
        string Path { get; }
        Task<IEntity[]> GetDataEntity(Pagination? pagination = null);
    }
}
