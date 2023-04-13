namespace RentmanSharp.Facade
{
    public class Appointment : AbstractFacade<Entity.Appointment>
    {
        public Appointment() : base()
        {
        }
        internal Appointment(Entity.Appointment entity) : base(entity)
        {
        }
    }
}