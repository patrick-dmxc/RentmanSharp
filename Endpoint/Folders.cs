namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Contacts, equipment, crew, vehicles and containers are organised into folders.
    /// </summary>
    public class Folders : AbstractEndpoint<Entity.Folder, Facade.Folder>
    {
        public override string Path { get => "folders"; }
    }
}