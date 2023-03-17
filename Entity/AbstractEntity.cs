namespace RentmanSharp.Entity
{
    public abstract class AbstractEntity : IEntity
    {
        [JsonPropertyName("id")]
        public uint ID { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }
        [JsonPropertyName("creator")]
        public string Creator { get; set; }
        [JsonPropertyName("displayname")]
        public string DisplayName { get; set; }
        [JsonPropertyName("updateHash")]
        public string updateHash { get; set; }

        [JsonConstructor]
        protected AbstractEntity(uint id, DateTime created, DateTime modified, string creator, string displayName, string updateHash)
        {
            ID = id;
            Created = created;
            Modified = modified;
            Creator = creator;
            DisplayName = displayName;
            this.updateHash = updateHash;
        }

        public override string ToString()
        {
            return $"{ID}\t{DisplayName}";
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode() + updateHash.GetHashCode();
        }
    }
}
