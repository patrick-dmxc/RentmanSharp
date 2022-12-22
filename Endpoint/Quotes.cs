using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents quotes.
    /// </summary>
    public class Quotes : AbstractEndpoint<Quote>
    {
        public override string Path { get => "quotes"; }
    }
}