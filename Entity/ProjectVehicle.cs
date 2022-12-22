using System.Text.Json;
using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class ProjectVehicle : AbstractEntity
    {
        public string? Name { get; set; }
        public string? Cost_Rate { get; set; }
        public string? Function { get; set; }
        public string? Transport { get; set; }
        public string? Vehicle { get; set; }
        public DateTime? Planningperiod_Start { get; set; }
        public DateTime? Planningperiod_End { get; set; }
        public string? Remark { get; set; }
        public string? Remark_Planner { get; set; }
        public double Costs { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"ProjectVehicle\t{ID}\t{DisplayName} ";
        }
        [JsonConverter(typeof(ETransportConverter))]
        public enum ETransport
        {
            NoTransport,
            RoundTrip,
            OnlyWayThere,
            OnlyWayBack
        }
    }
}