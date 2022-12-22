using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents serial numbers, which are specific individual equipment pieces. This is a sub-item of Equipment and is always associated with a single Equipment item.
    /// </summary>
    public class SerialNumbers : AbstractEndpoint<SerialNumber>
    {
        public override string Path { get => "serialnumbers"; }
    }
}