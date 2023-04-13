namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// All equipment.
    /// </summary>
    public class Equipment : AbstractEndpoint<Entity.EquipmentItem, Facade.EquipmentItem>
    {
        public override string Path { get => "equipment"; }

        public static Filter DEFAULT_FILTER = new Filter(new Pagination(100));
        protected override Filter? DefaultFilter => DEFAULT_FILTER;
        public async Task<Facade.EquipmentSetsContentItem[]> GetLinkedEquipmentSetsContentCollectionEntity(uint id, Filter? filter = null)
        {
            EquipmentSetsContent equipmentSetsContent = Connection.Instance.GetEndpoint<EquipmentSetsContent>();
            return await equipmentSetsContent.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.SerialNumber[]> GetLinkedSerialNumbersCollectionEntity(uint id, Filter? filter = null)
        {
            SerialNumbers serialNumbers = Connection.Instance.GetEndpoint<SerialNumbers>();
            return await serialNumbers.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.Repair[]> GetLinkedRepairsCollectionEntity(uint id, Filter? filter = null)
        {
            Repairs repairs = Connection.Instance.GetEndpoint<Repairs>();
            return await repairs.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.StockMovement[]> GetLinkedStockMovementsCollectionEntity(uint id, Filter? filter = null)
        {
            StockMovements stockMovements = Connection.Instance.GetEndpoint<StockMovements>();
            return await stockMovements.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.Accessorie[]> GetLinkedAccessoriesCollectionEntity(uint id, Filter? filter = null)
        {
            Accessories accessories = Connection.Instance.GetEndpoint<Accessories>();
            return await accessories.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
        public async Task<Facade.File[]> GetLinkedFilesCollectionEntity(uint id, Filter? filter = null)
        {
            Files files = Connection.Instance.GetEndpoint<Files>();
            return await files.GetCollection(BaseUrl + $"/{Path}/{id}", filter);
        }
    }
}