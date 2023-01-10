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
            RateFactors? rateFactors = Connection.Instance.GetEndpoint(typeof(RateFactors)) as RateFactors;
            if (rateFactors == null)
                throw new NotSupportedException();
            return await rateFactors.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}