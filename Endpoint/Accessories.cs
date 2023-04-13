namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents accessories of an equipment item. Each equipment can have multiple accessories. Accessories are equipment items themselves.
    /// </summary>
    public class Accessories : AbstractEndpoint<Entity.Accessorie, Facade.Accessorie>
    {
        public override string Path { get => "accessories"; }
    }
}