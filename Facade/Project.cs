namespace RentmanSharp.Facade
{
    public class Project : AbstractFacade<Entity.Project>
    {
        public Project() : base()
        {
        }
        internal Project(Entity.Project entity) : base(entity)
        {
        }
    }
}