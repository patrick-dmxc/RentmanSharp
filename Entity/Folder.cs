namespace RentmanSharp.Entity
{
    public class Folder : AbstractEntity
    {

        [JsonPropertyName("parent")]
        public string Parent { get; }
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("order")]
        public int Order { get; }
        [JsonPropertyName("itemtype")]
        public EFolderItemType ItemType { get; }
        [JsonPropertyName("path")]
        public string Path { get; }
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        public Folder(uint id, DateTime created, DateTime modified, string creator, string displayName,
                      string updateHash, string parent, string name, int order, EFolderItemType itemType,
                      string path, JsonElement custom) : base(id, created, modified, creator, displayName, updateHash)
        {
            Parent = parent;
            Name = name;
            Order = order;
            ItemType = itemType;
            Path = path;
            Custom = custom;
        }

        public override string ToString()
        {
            return $"Folder\t{ID}\t{DisplayName} {Path}";
        }
        [JsonConverter(typeof(EFolderItemTypeConverter))]
        public enum EFolderItemType
        {
            Equipment,
            Contact,
            Vehicle,
            User,
            Container,
        }
    }
}