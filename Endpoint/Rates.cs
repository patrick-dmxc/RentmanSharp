using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents crew rates.
    /// </summary>
    public class Rates : AbstractEndpoint<Rate>
    {
        public override string Path { get => "rates"; }
    }
}