using System.Drawing;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class StockMovement : AbstractEntity
    {
        public int? Amount { get; set; }
        public string? Equipment { get; set; }
        public string? ProjectEquipment { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public DateTime? Date { get; set; }
        public string? Stock_Location { get; set; }
        public EStockMovementType Type { get; set; }

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