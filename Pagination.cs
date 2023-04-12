namespace RentmanSharp
{
    public readonly struct Pagination
    {
        public readonly int Limit;
        public readonly int? Offset;
        public Pagination(in int limit=300,in int? offset=0)
        {
            this.Limit = limit;
            this.Offset = offset;
        }

        public Pagination Next()
        {
            return new Pagination(this.Limit, this.Offset + this.Limit);
        }

        public override string ToString()
        {
            if(this.Offset.HasValue)
                return $"?limit={this.Limit}&offset={this.Offset}";
            return $"?limit={this.Limit}";
        }

        public static implicit operator Pagination?(Response response)
        {
            return new Pagination(response.Limit, response.Offset);
        }
    }
}
