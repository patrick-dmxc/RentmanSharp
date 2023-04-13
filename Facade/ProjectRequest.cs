namespace RentmanSharp.Facade
{
    public class ProjectRequest : AbstractFacade<Entity.ProjectRequest>
    {
        public ProjectRequest() : base()
        {
        }
        internal ProjectRequest(Entity.ProjectRequest entity) : base(entity)
        {
        }
    }
}