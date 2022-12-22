using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve repairs and their information.
    /// </summary>
    public class Repairs : AbstractEndpoint<Repair>
    {
        public override string Path { get => "repairs"; }
    }
}