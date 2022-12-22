using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents accessories of an equipment item. Each equipment can have multiple accessories. Accessories are equipment items themselves.
    /// </summary>
    public class Accessories : AbstractEndpoint<Accessorie>
    {
        public override string Path { get => "accessories"; }
    }
}