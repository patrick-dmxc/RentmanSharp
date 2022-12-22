using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents contracts.
    /// </summary>
    public class Contracts : AbstractEndpoint<Contract>
    {
        public override string Path { get => "contracts"; }
    }
}