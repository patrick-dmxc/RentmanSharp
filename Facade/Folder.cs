namespace RentmanSharp.Facade
{
    public class Folder : AbstractFacade<Entity.Folder>
    {
        public Folder() : base()
        {
        }
        internal Folder(Entity.Folder entity) : base(entity)
        {
        }
    }
}