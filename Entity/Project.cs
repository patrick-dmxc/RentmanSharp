using System.Drawing;

namespace RentmanSharp.Entity
{
    public class Project : AbstractEntity
    {
        [JsonPropertyName("location")]
        public string? Location { get; }
        [JsonPropertyName("refundabledeposit")]
        public double RefundableDeposit { get; }
        [JsonPropertyName("deposit_status")]
        public EDepositStatus Deposit_Status { get; }
        [JsonPropertyName("customer")]
        public string? Customer { get; }
        [JsonPropertyName("loc_contact")]
        public string? Loc_Contact { get; }
        [JsonPropertyName("cust_contact")]
        public string? Cust_Contact { get; }
        [JsonPropertyName("project_type")]
        public string Project_Type { get; }
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("reference")]
        public string Reference { get; }
        [JsonPropertyName("number")]
        public int Number { get; }
        [JsonPropertyName("account_manager")]
        public string Account_Manager { get; }
        [JsonPropertyName("color")]
        [JsonConverter(typeof(Converter.ColorConverter))]
        public Color Color { get; }
        [JsonPropertyName("already_invoiced")]
        public double Already_Invoiced { get; }
        [JsonPropertyName("tags")]
        public string Tags { get; }
        [JsonPropertyName("usageperiod_start")]
        public DateTime? Usageperiod_Start { get; }
        [JsonPropertyName("usageperiod_end")]
        public DateTime? Usageperiod_End { get; }
        [JsonPropertyName("planperiod_start")]
        public DateTime? Planperiod_Start { get; }
        [JsonPropertyName("planperiod_end")]
        public DateTime? Planperiod_End { get; }
        [JsonPropertyName("volume")]
        public double Volume { get; }
        [JsonPropertyName("weight")]
        public double Weight { get; }
        [JsonPropertyName("power")]
        public double Power { get; }
        [JsonPropertyName("current")]
        public double Current { get; }
        [JsonPropertyName("equipment_period_from")]
        public DateTime? Equipment_Period_From { get; }
        [JsonPropertyName("equipment_period_to")]
        public DateTime? Equipment_Period_To { get; }
        [JsonPropertyName("purchasecosts")]
        public double PurchaseCosts { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        public Project(uint id, DateTime created, DateTime modified, string creator, string displayName,
                       string updateHash, string? location, double refundableDeposit, EDepositStatus deposit_Status,
                       string? customer, string? loc_Contact, string? cust_Contact, string project_Type, string name,
                       string reference, int number, string account_Manager, Color color, double already_Invoiced,
                       string tags, DateTime? usageperiod_Start, DateTime? usageperiod_End, DateTime? planperiod_Start,
                       DateTime? planperiod_End, double volume, double weight, double power, double current,
                       DateTime? equipment_Period_From, DateTime? equipment_Period_To, double purchaseCosts,
                       JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Location = location;
            RefundableDeposit = refundableDeposit;
            Deposit_Status = deposit_Status;
            Customer = customer;
            Loc_Contact = loc_Contact;
            Cust_Contact = cust_Contact;
            Project_Type = project_Type;
            Name = name;
            Reference = reference;
            Number = number;
            Account_Manager = account_Manager;
            Color = color;
            Already_Invoiced = already_Invoiced;
            Tags = tags;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Volume = volume;
            Weight = weight;
            Power = power;
            Current = current;
            Equipment_Period_From = equipment_Period_From;
            Equipment_Period_To = equipment_Period_To;
            PurchaseCosts = purchaseCosts;
            Custom = custom;
        }

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