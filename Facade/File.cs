namespace RentmanSharp.Facade
{
    public class File : AbstractFacade<Entity.File>
    {
        public File() : base()
        {
        }
        internal File(Entity.File entity) : base(entity)
        {
        }
    }
}