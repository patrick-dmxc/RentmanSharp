namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint, you can retrieve the stock locations and their information.
    /// </summary>
    public class StockLocations : AbstractEndpoint<Entity.StockLocation, Facade.StockLocation>
    {
        public override string Path { get => "stocklocations"; }
    }
}