using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a person or department within a Contact. A Person item is always associated with one Contact.
    /// </summary>
    public class Contactpersons : AbstractEndpoint<Contactperson>
    {
        public override string Path { get => "contactpersons"; }
        public async Task<Contactperson?> UpdateItem(Contactperson item, uint id)
        {
            return await UpdateItemInternal(id, item);
        }
        public async Task DeleteItem(uint id)
        {
            await DeleteItemInternal(id);
        }
    }
}