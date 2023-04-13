using RentmanSharp.Facade;

namespace RentmanSharp.Endpoint
{
    public interface IEndpoint
    {
        string Path { get; }
        Task<IFacade[]> GetCollectionFacades(Filter? filter = null);
        Task<IFacade> GetItemFacade(uint id);
    }
}
