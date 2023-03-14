using System.Text.Json.Serialization;

namespace RentmanSharp.Entity
{
    public class File : AbstractEntity
    {
        [JsonPropertyName("readable_name")]
        public string? Readable_Name { get; }
        [JsonPropertyName("expiration")]
        public string? Expiration { get; }
        [JsonPropertyName("size")]
        public int Size { get; }
        [JsonPropertyName("image")]
        public bool Image { get; }
        [JsonPropertyName("item")]
        public int Item { get; }
        [JsonPropertyName("itemtype")]
        public string? ItemType { get; }
        [JsonPropertyName("description")]
        public string? Description { get; }
        [JsonPropertyName("in_documents")]
        public bool In_Documents { get; }
        [JsonPropertyName("in_webshop")]
        public bool In_Webshop { get; }
        [JsonPropertyName("classified")]
        public bool Classified { get; }
        [JsonPropertyName("public")]
        public bool Public { get; }
        [JsonPropertyName("type")]
        public string? Type { get; }
        [JsonPropertyName("preview_of")]
        public string? Preview_of { get; }
        [JsonPropertyName("previewstatus")]
        public EFilePreviewStatus? PreviewStatus { get; }
        [JsonPropertyName("file_item")]
        public int File_Item { get; }
        [JsonPropertyName("file_itemtype")]
        public string? File_ItemType { get; }
        [JsonPropertyName("path")]
        public string? Path { get; }
        [JsonPropertyName("url")]
        public string? URL { get; }
        [JsonPropertyName("proxy_url")]
        public string? Proxy_URL { get; }

        [JsonConstructor]
        public File(uint? id, DateTime? created, DateTime? modified, string? creator, string? displayName,
                    string? updateHash, string? readable_Name, string? expiration, int size, bool image, int item,
                    string? itemType, string? description, bool in_Documents, bool in_Webshop, bool classified,
                    bool @public, string? type, string? preview_of, EFilePreviewStatus? previewStatus, int file_Item,
                    string? file_ItemType, string? path, string? uRL, string? proxy_URL) : base(id, created, modified, creator, displayName, updateHash)
        {
            Readable_Name = readable_Name;
            Expiration = expiration;
            Size = size;
            Image = image;
            Item = item;
            ItemType = itemType;
            Description = description;
            In_Documents = in_Documents;
            In_Webshop = in_Webshop;
            Classified = classified;
            Public = @public;
            Type = type;
            Preview_of = preview_of;
            PreviewStatus = previewStatus;
            File_Item = file_Item;
            File_ItemType = file_ItemType;
            Path = path;
            URL = uRL;
            Proxy_URL = proxy_URL;
        }

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
