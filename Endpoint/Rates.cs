using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents crew rates.
    /// </summary>
    public class Rates : AbstractEndpoint<Rate>
    {
        public override string Path { get => "rates"; }
        public async Task<RateFactor[]> GetLinkedRateFactorsCollectionEntity(uint id, Filter? filter = null)
        {
            RateFactors rateFactors = Connection.Instance.GetEndpoint<RateFactors>();
            return await rateFactors.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}