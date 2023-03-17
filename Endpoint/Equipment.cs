using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// All equipment.
    /// </summary>
    public class Equipment : AbstractEndpoint<EquipmentItem>
    {
        public override string Path { get => "equipment"; }

        public static Filter DEFAULT_FILTER = new Filter(new Pagination(100));
        protected override Filter? DefaultFilter => DEFAULT_FILTER;
        public async Task<EquipmentSetsContentItem[]> GetLinkedEquipmentSetsContentCollectionEntity(uint id, Filter? filter = null)
        {
            EquipmentSetsContent equipmentSetsContent = Connection.Instance.GetEndpoint<EquipmentSetsContent>();
            return await equipmentSetsContent.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<SerialNumber[]> GetLinkedSerialNumbersCollectionEntity(uint id, Filter? filter = null)
        {
            SerialNumbers serialNumbers = Connection.Instance.GetEndpoint<SerialNumbers>();
            return await serialNumbers.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Repair[]> GetLinkedRepairsCollectionEntity(uint id, Filter? filter = null)
        {
            Repairs repairs = Connection.Instance.GetEndpoint<Repairs>();
            return await repairs.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<StockMovement[]> GetLinkedStockMovementsCollectionEntity(uint id, Filter? filter = null)
        {
            StockMovements stockMovements = Connection.Instance.GetEndpoint<StockMovements>();
            return await stockMovements.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Accessorie[]> GetLinkedAccessoriesCollectionEntity(uint id, Filter? filter = null)
        {
            Accessories accessories = Connection.Instance.GetEndpoint<Accessories>();
            return await accessories.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}