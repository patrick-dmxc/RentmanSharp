using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents invoices.
    /// </summary>
    public class Invoices : AbstractEndpoint<Invoice>
    {
        public override string Path { get => "invoices"; }
    }
}