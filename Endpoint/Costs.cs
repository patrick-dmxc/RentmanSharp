using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents additional costs in a project.
    /// </summary>
    public class Costs : AbstractEndpoint<Cost>
    {
        public override string Path { get => "costs"; }
    }
}