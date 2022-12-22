using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a person or department within a Contact. A Person item is always associated with one Contact.
    /// </summary>
    public class Contactpersons : AbstractEndpoint<Contactperson>
    {
        public override string Path { get => "contactpersons"; }
    }
}