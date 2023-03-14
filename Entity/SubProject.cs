using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class SubProject : AbstractEntity
    {
        [JsonPropertyName("project")]
        public string? Project { get; }
        [JsonPropertyName("order")]
        public int? Order { get; }
        [JsonPropertyName("name")]
        public string? Name { get; }
        [JsonPropertyName("status")]
        public string? Status { get; }
        [JsonPropertyName("is_template")]
        public bool Is_Template { get; }
        [JsonPropertyName("location")]
        public string? Location { get; }
        [JsonPropertyName("loc_contact")]
        public string? Loc_Contact { get; }
        [JsonPropertyName("insurance_rate")]
        public double Insurance_Rate { get; }
        [JsonPropertyName("discount_rental")]
        public double Discount_Rental { get; }
        [JsonPropertyName("discount_sale")]
        public double Discount_Sale { get; }
        [JsonPropertyName("discount_crew")]
        public double Discount_Crew { get; }
        [JsonPropertyName("discount_transport")]
        public double Discount_Transport { get; }
        [JsonPropertyName("discount_additional_dosts")]
        public double Discount_Additional_Costs { get; }
        [JsonPropertyName("discount_subproject")]
        public double Discount_Subproject { get; }
        [JsonPropertyName("discount_fixed")]
        public bool Discount_Fixed { get; }
        [JsonPropertyName("discount_fixed_amount")]
        public double Discount_Fixed_Amount { get; }
        [JsonPropertyName("fixed_price")]
        public bool Fixed_Price { get; }
        [JsonPropertyName("in_planning")]
        public bool In_Planning { get; }
        [JsonPropertyName("in_financial")]
        public bool In_Financial { get; }
        [JsonPropertyName("asset_location_from")]
        public string? Asset_Location_From { get; }
        [JsonPropertyName("already_invoiced")]
        public double Already_Invoiced { get; }
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
        [JsonPropertyName("purchasecosts")]
        public double PurchaseCosts { get; }
        [JsonPropertyName("equipment_period_from")]
        public DateTime? Equipment_Period_From { get; }
        [JsonPropertyName("equipment_period_to")]
        public DateTime? Equipment_Period_To { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public SubProject(
            uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName, string? updateHash,
            string? project, int? order, string? name, string? status, bool is_Template, string? location,
            string? loc_Contact, double insurance_Rate, double discount_Rental, double discount_Sale,
            double discount_Crew, double discount_Transport, double discount_Additional_Costs,
            double discount_Subproject, bool discount_Fixed, double discount_Fixed_Amount, bool fixed_Price,
            bool in_Planning, bool in_Financial, string? asset_Location_From, double already_Invoiced,
            DateTime? usageperiod_Start, DateTime? usageperiod_End, DateTime? planperiod_Start, DateTime? planperiod_End,
            double volume, double weight, double power, double current, double purchaseCosts,
            DateTime? equipment_Period_From, DateTime? equipment_Period_To, JsonElement custom) : base(id,
            created, modified, creator, displayName, updateHash)
        {
            Project = project;
            Order = order;
            Name = name;
            Status = status;
            Is_Template = is_Template;
            Location = location;
            Loc_Contact = loc_Contact;
            Insurance_Rate = insurance_Rate;
            Discount_Rental = discount_Rental;
            Discount_Sale = discount_Sale;
            Discount_Crew = discount_Crew;
            Discount_Transport = discount_Transport;
            Discount_Additional_Costs = discount_Additional_Costs;
            Discount_Subproject = discount_Subproject;
            Discount_Fixed = discount_Fixed;
            Discount_Fixed_Amount = discount_Fixed_Amount;
            Fixed_Price = fixed_Price;
            In_Planning = in_Planning;
            In_Financial = in_Financial;
            Asset_Location_From = asset_Location_From;
            Already_Invoiced = already_Invoiced;
            Usageperiod_Start = usageperiod_Start;
            Usageperiod_End = usageperiod_End;
            Planperiod_Start = planperiod_Start;
            Planperiod_End = planperiod_End;
            Volume = volume;
            Weight = weight;
            Power = power;
            Current = current;
            PurchaseCosts = purchaseCosts;
            Equipment_Period_From = equipment_Period_From;
            Equipment_Period_To = equipment_Period_To;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"SubProject\t{ID}\t{DisplayName} ";
        }
    }
}