using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Contacts, equipment, crew, vehicles and containers are organised into folders.
    /// </summary>
    public class Folders : AbstractEndpoint<Folder>
    {
        public override string Path { get => "folders"; }
    }
}