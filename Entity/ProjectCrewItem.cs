using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class ProjectCrewItem : AbstractEntity
    {
        public string? Cost_Rate { get; set; }
        public string? Function { get; set; }
        public string? CrewMember { get; set; }
        public bool visible { get; set; }
        public DateTime? Planperiod_Start { get; set; }
        public DateTime? Planperiod_End { get; set; }
        public string? Transport { get; set; }
        public string? Remark { get; set; }
        public string? Remark_Planner { get; set; }
        public string? Invoice_Reference { get; set; }
        public bool Project_Leader { get; set; }
        public bool Is_Visible_On_Dashboard { get; set; }
        public double Costs { get; set; }
        public double Cost_Actual { get; set; }
        public int Hours_Registered { get; set; }
        public int Hours_Planned { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"ProjectCrew\t{ID}\t{DisplayName} {Planperiod_Start} - {Planperiod_End}";
        }
    }
}