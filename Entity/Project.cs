using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class Project : AbstractEntity
    {
        public string? Location { get; set; }
        public double RefundableDeposit { get; set; }
        public EDepositStatus Deposit_Status { get; set; }
        public string? Customer { get; set; }
        public string? Loc_Contact { get; set; }
        public string? Cust_Contact { get; set; }
        public string? Project_Type { get; set; }
        public string? Name { get; set; }
        public string? Reference { get; set; }
        public int Number { get; set; }
        public string? Account_Manager { get; set; }
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; set; }
        public double Already_Invoiced { get; set; }
        public string? Tags { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public double Power { get; set; }
        public double Current { get; set; }
        public DateTime? Equipment_Period_From { get; set; }
        public DateTime? Equipment_Period_To { get; set; }
        public double PurchaseCosts { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Project\t{ID}\t{DisplayName} ";
        }
        [JsonConverter(typeof(EDepositStatusConverter))]
        public enum EDepositStatus
        {
            no_deposit_paid,
            deposit_paid,
            deposit_returned
        }
    }
}