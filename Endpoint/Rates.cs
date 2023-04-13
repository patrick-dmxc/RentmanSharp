namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents crew rates.
    /// </summary>
    public class Rates : AbstractEndpoint<Entity.Rate, Facade.Rate>
    {
        public override string Path { get => "rates"; }
        public async Task<Facade.RateFactor[]> GetLinkedRateFactorsCollectionEntity(uint id, Filter? filter = null)
        {
            RateFactors rateFactors = Connection.Instance.GetEndpoint<RateFactors>();
            return await rateFactors.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}