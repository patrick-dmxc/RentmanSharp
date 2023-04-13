namespace RentmanSharp.Facade
{
    public class ProjectVehicle : AbstractFacade<Entity.ProjectVehicle>
    {
        public ProjectVehicle() : base()
        {
        }
        internal ProjectVehicle(Entity.ProjectVehicle entity) : base(entity)
        {
        }
    }
}