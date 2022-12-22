using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class SubProject : AbstractEntity
    {
        public string? Project { get; set; }
        public int? Order { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public bool Is_Template { get; set; }
        public string? Location { get; set; }
        public string? Loc_Contact { get; set; }
        public double Insurance_Rate { get; set; }
        public double Discount_Rental { get; set; }
        public double Discount_Sale { get; set; }
        public double Discount_Crew { get; set; }
        public double Discount_Transport { get; set; }
        public double Discount_Additional_Costs { get; set; }
        public double Discount_Subproject { get; set; }
        public bool Discount_Fixed { get; set; }
        public double Discount_Fixed_Amount { get; set; }
        public bool Fixed_Price { get; set; }
        public bool In_Planning { get; set; }
        public bool In_Financial { get; set; }
        public string? Asset_Location_From { get; set; }
        public double Already_Invoiced { get; set; }
        public DateTime? Usageperiod_Start { get; set; }
        public DateTime? Usageperiod_End { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public double Power { get; set; }
        public double Current { get; set; }
        public double PurchaseCosts { get; set; }
        public DateTime? Equipment_Period_From { get; set; }
        public DateTime? Equipment_Period_To { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"SubProject\t{ID}\t{DisplayName} ";
        }
    }
}