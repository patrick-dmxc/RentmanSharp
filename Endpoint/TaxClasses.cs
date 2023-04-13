namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents tax classes, which can be used to configure taxation rates.
    /// </summary>
    public class TaxClasses : AbstractEndpoint<Entity.TaxClass, Facade.TaxClass>
    {
        public override string Path { get => "taxclasses"; }
    }
}