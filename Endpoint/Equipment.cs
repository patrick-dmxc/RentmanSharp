using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// All equipment.
    /// </summary>
    public class Equipment : AbstractEndpoint<EquipmentItem>
    {
        public override string Path { get => "equipment"; }

        private static Pagination DEFAULT_PAGINATION = new Pagination(100);
        protected override Pagination? DefaultPagination => DEFAULT_PAGINATION;
        public async Task<EquipmentSetsContentItem[]> GetLinkedEquipmentSetsContentCollectionEntity(uint id, Pagination? pagination = null)
        {
            EquipmentSetsContent? equipmentSetsContent = Connection.Instance.GetEndpoint(typeof(EquipmentSetsContent)) as EquipmentSetsContent;
            if (equipmentSetsContent == null)
                throw new NotSupportedException();
            return await equipmentSetsContent.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<SerialNumber[]> GetLinkedSerialNumbersCollectionEntity(uint id, Pagination? pagination = null)
        {
            SerialNumbers? serialNumbers = Connection.Instance.GetEndpoint(typeof(SerialNumbers)) as SerialNumbers;
            if (serialNumbers == null)
                throw new NotSupportedException();
            return await serialNumbers.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<Repair[]> GetLinkedRepairsCollectionEntity(uint id, Pagination? pagination = null)
        {
            Repairs? repairs = Connection.Instance.GetEndpoint(typeof(Repairs)) as Repairs;
            if (repairs == null)
                throw new NotSupportedException();
            return await repairs.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<StockMovement[]> GetLinkedStockMovementsCollectionEntity(uint id, Pagination? pagination = null)
        {
            StockMovements? stockMovements = Connection.Instance.GetEndpoint(typeof(StockMovements)) as StockMovements;
            if (stockMovements == null)
                throw new NotSupportedException();
            return await stockMovements.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
        public async Task<Accessorie[]> GetLinkedAccessoriesCollectionEntity(uint id, Pagination? pagination = null)
        {
            Accessories? accessories = Connection.Instance.GetEndpoint(typeof(Accessories)) as Accessories;
            if (accessories == null)
                throw new NotSupportedException();
            return await accessories.GetCollection(BaseUrl + $"/{Path}/{id}", pagination);
        }
    }
}