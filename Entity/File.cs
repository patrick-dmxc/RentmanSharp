using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class File : AbstractEntity
    {
        public string? Readable_Name { get; set; }
        public string? Expiration { get; set; }
        public int Size { get; set; }
        public bool Image { get; set; }
        public int Item { get; set; }
        public string? ItemType { get; set; }
        public string? Description { get; set; }
        public bool In_Documents { get; set; }
        public bool In_Webshop { get; set; }
        public bool Classified { get; set; }
        public bool Public { get; set; }
        public string? Type { get; set; }
        public string? Preview_of { get; set; }
        public EFilePreviewStatus? PreviewStatus { get; set; }
        public int File_Item { get; set; }
        public string? File_ItemType { get; set; }
        public string? Path { get; set; }
        public string? URL { get; set; }
        public string? Proxy_URL { get; set; }

        public override string ToString()
        {
            return $"File\t{ID}\t{Path}";
        }
        [JsonConverter(typeof(EFilePreviewStatusConverter))]
        public enum EFilePreviewStatus
        {
            No,
            Yes,
            Failed
        }
    }
}
