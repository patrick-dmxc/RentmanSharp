using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you can retrieve the stock locations and their information.
    /// </summary>
    public class StockLocations : AbstractEndpoint<StockLocation>
    {
        public override string Path { get => "stocklocations"; }
    }
}