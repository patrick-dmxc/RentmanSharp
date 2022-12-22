using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve subrentals and their information.
    /// </summary>
    public class Subrentals : AbstractEndpoint<Subrental>
    {
        public override string Path { get => "subrentals"; }
    }
}