using System.Text.Json;

namespace RentmanSharp.Entity
{
    public class Cost : AbstractEntity
    {
        public string? Name { get; set; }
        public string? Remark { get; set; }
        public string? Project { get; set; }
        public string? Subproject { get; set; }
        public bool Is_Template { get; set; }
        public string? Taxclass { get; set; }
        public string? Ledger { get; set; }
        public double Verkoopprijs { get; set; }
        public double Inkoopprijs { get; set; }
        public double Price { get; set; }
        public JsonElement Custom { get; set; }

        public override string ToString()
        {
            return $"Cost\t{ID}\t{DisplayName} {Price}EUR {Verkoopprijs}EUR {Inkoopprijs}EUR";
        }
    }
}
