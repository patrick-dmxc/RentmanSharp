namespace RentmanSharp.Facade
{
    public abstract class AbstractFacade<T> : IFacade where T : class, Entity.IEntity
    {
        public uint ID { get { return Entity?.ID ?? 0; } }
        public T? Entity { get; private set; } = null;
        protected AbstractFacade()
        {
        }
        protected AbstractFacade(T entity) : this()
        {
            Entity = entity;
        }
        internal async Task UpdateViaEntity(T entity)
        {
            await updateViaEntityInternal(Entity, entity);
            Entity = entity;
        }
        protected virtual async Task updateViaEntityInternal(T? oldEntity, T newEntity)
        {
            await Task.Delay(0);
        }

        public override string ToString()
        {
            return Entity?.ToString() ?? base.ToString()!;
        }
        public override bool Equals(object? obj)
        {
            if (obj is AbstractFacade<T> other)
                return uint.Equals(other.ID, ID);
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.GetType().Name.GetHashCode(), ID);
        }
    }
}