using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents additional costs in a project.
    /// </summary>
    public class Costs : AbstractEndpoint<Entity.Cost, Facade.Cost>
    {
        public override string Path { get => "costs"; }
        public async Task<Cost?> UpdateItem(Cost item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
    }
}