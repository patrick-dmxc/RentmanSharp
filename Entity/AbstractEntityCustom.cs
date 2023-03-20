namespace RentmanSharp.Entity
{
    public abstract class AbstractEntityCustom : AbstractEntity
    {
        [JsonPropertyName("custom")]
        public JsonElement Custom { get; }

        [JsonConstructor]
        protected AbstractEntityCustom(uint id, DateTime created, DateTime modified, string creator, string displayName, string updateHash,
                       JsonElement custom): base(id, created, modified, creator, displayName, updateHash)
        {
            Custom=custom;
        }
    }
}
