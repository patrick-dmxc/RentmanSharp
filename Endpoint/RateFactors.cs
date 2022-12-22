using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents the rate factors for the crew rates.
    /// </summary>
    public class RateFactors : AbstractEndpoint<RateFactor>
    {
        public override string Path { get => "ratefactors"; }
    }
}