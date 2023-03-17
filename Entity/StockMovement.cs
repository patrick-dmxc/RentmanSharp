namespace RentmanSharp.Entity
{
    public class StockMovement : AbstractEntity
    {
        [JsonPropertyName("amount")]
        public int Amount { get; }
        [JsonPropertyName("equipment")]
        public string Equipment { get; }
        [JsonPropertyName("projectequipment")]
        public string ProjectEquipment { get; }
        [JsonPropertyName("description")]
        public string Description { get; }
        [JsonPropertyName("details")]
        public string Details { get; }
        [JsonPropertyName("date")]
        public DateTime Date { get; }
        [JsonPropertyName("stock_location")]
        public string Stock_Location { get; }
        [JsonPropertyName("type")]
        public EStockMovementType Type { get; }

        [JsonConstructor]
        public StockMovement(
            uint id, DateTime created, DateTime modified, string creator, string displayName, string updateHash,
            int amount, string equipment, string projectEquipment, string description, string details,
            DateTime date, string stock_Location, EStockMovementType type) : base(id, created, modified, creator, displayName, updateHash)
        {
            Amount = amount;
            Equipment = equipment;
            ProjectEquipment = projectEquipment;
            Description = description;
            Details = details;
            Date = date;
            Stock_Location = stock_Location;
            Type = type;
        }

        public override string ToString()
        {
            return $"StockMovement\t{ID}\t{Date}\t{DisplayName}";
        }

        [JsonConverter(typeof(EStockMovementTypeConverter))]
        public enum EStockMovementType
        {
            Manual,
            EquipmentLost,
            EquipmentFound,
            SerialCreated,
            SerialDeleted,
            SerialDeactivated,
            SerialActivatedOrFound,
            SerialLost,
            StockCorrected_CountingSerials,
            EquipmentImported,
            InitialMutation,
            CountjobCorrection,
            SerialTransferred,
            CaseTransfer,
            BulkTransfer
        }
    }
}