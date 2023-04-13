namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Get a status objects
    /// </summary>
    public class Statuses : AbstractEndpoint<Entity.Status, Facade.Status>
    {
        public override string Path { get => "statuses"; }
    }
}