using static RentmanSharp.Entity.StockMovement;

namespace RentmanSharp.Entity
{
    public class EStockMovementTypeConverter : JsonConverter<EStockMovementType>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EStockMovementType);
        }

        public override EStockMovementType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = (string?)reader.GetString();
            if (string.IsNullOrWhiteSpace(enumString))
                throw new NotImplementedException();
            switch (enumString)
            {
                case "manual":
                    return EStockMovementType.Manual;
                case "equipment_lost":
                    return EStockMovementType.EquipmentLost;
                case "equipment_found":
                    return EStockMovementType.EquipmentFound;
                case "serial_created":
                    return EStockMovementType.SerialCreated;
                case "serial_deleted":
                    return EStockMovementType.SerialDeleted;
                case "serial_deactivated":
                    return EStockMovementType.SerialDeactivated;
                case "serial_activated_or_found":
                    return EStockMovementType.SerialActivatedOrFound;
                case "serial_lost":
                    return EStockMovementType.SerialLost;
                case "stock_corrected_counting_serials":
                    return EStockMovementType.StockCorrected_CountingSerials;
                case "equipment_imported":
                    return EStockMovementType.EquipmentImported;
                case "initial_mutation":
                    return EStockMovementType.InitialMutation;
                case "countjob_correction":
                    return EStockMovementType.CountjobCorrection;
                case "serial_transferred":
                    return EStockMovementType.SerialTransferred;
                case "case_transfer":
                    return EStockMovementType.CaseTransfer;
                case "bulk_transfer":
                    return EStockMovementType.BulkTransfer;
            }
            return (EStockMovementType)Enum.Parse(typeof(EStockMovementType), enumString, true);
        }

        public override void Write(Utf8JsonWriter writer, EStockMovementType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case EStockMovementType.Manual:
                    writer.WriteStringValue("manual");
                    break;
                case EStockMovementType.EquipmentLost:
                    writer.WriteStringValue("equipment_lost");
                    break;
                case EStockMovementType.EquipmentFound:
                    writer.WriteStringValue("equipment_found");
                    break;
                case EStockMovementType.SerialCreated:
                    writer.WriteStringValue("serial_created");
                    break;
                case EStockMovementType.SerialDeleted:
                    writer.WriteStringValue("serial_deleted");
                    break;
                case EStockMovementType.SerialDeactivated:
                    writer.WriteStringValue("serial_deactivated");
                    break;
                case EStockMovementType.SerialActivatedOrFound:
                    writer.WriteStringValue("serial_activated_or_found");
                    break;
                case EStockMovementType.SerialLost:
                    writer.WriteStringValue("serial_lost");
                    break;
                case EStockMovementType.StockCorrected_CountingSerials:
                    writer.WriteStringValue("stock_corrected_counting_serials");
                    break;
                case EStockMovementType.EquipmentImported:
                    writer.WriteStringValue("equipment_imported");
                    break;
                case EStockMovementType.InitialMutation:
                    writer.WriteStringValue("initial_mutation");
                    break;
                case EStockMovementType.CountjobCorrection:
                    writer.WriteStringValue("countjob_correction");
                    break;
                case EStockMovementType.SerialTransferred:
                    writer.WriteStringValue("serial_transferred");
                    break;
                case EStockMovementType.CaseTransfer:
                    writer.WriteStringValue("case_transfer");
                    break;
                case EStockMovementType.BulkTransfer:
                    writer.WriteStringValue("bulk_transfer");
                    break;
            }
            writer.WriteStringValue(value.ToString());
        }
    }
}