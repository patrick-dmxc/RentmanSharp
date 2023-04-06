namespace RentmanSharp
{
    public class Filter
    {
        public readonly FilterProperty[] FilterProperties;
        public readonly Pagination Pagination;
        public static Filter IncrementFilter = new IncrementFilter();
        public Filter(in Pagination? pagination = null, params FilterProperty[] filterProperties)
        {
            this.FilterProperties = filterProperties;
            this.Pagination = pagination ?? new Pagination(300, 0);
        }
        public Filter Next()
        {
            
            return new Filter(this.Pagination.Next(),FilterProperties);
        }

        public override string ToString()
        {
            string s = Pagination.ToString();

            foreach (var filterProperty in this.FilterProperties)
            {
                s += "&";
                s += filterProperty.ToString();
            }
            return s;
        }

        public readonly struct FilterProperty
        {
            public readonly string Name;
            public readonly string Value;
            public readonly EFilterOperator Operator;

            public FilterProperty(string name, string value, EFilterOperator @operator)
            {
                this.Name = name;
                this.Value = value;
                this.Operator = @operator;
            }

            public override string ToString()
            {
                return $"{this.Name}{operatorString(this.Operator)}={this.Value}";
            }

            private static string operatorString(EFilterOperator @operator)
            {
                switch (@operator)
                {
                    case EFilterOperator.Equals:
                        return string.Empty;
                    case EFilterOperator.LessThan:
                        return "[lt]";
                    case EFilterOperator.GreaterTan:
                        return "[gt]";
                    case EFilterOperator.LessThanOrEqualsTo:
                        return "[lte]";
                    case EFilterOperator.GreaterThanOrEqualsTo:
                        return "[gte]";
                    case EFilterOperator.NotEqualTo:
                        return "[neq]";
                    case EFilterOperator.IsNull:
                        return "[isnull]";
                }
                throw new NotImplementedException();
            }

            public enum EFilterOperator
            {
                Equals,
                LessThan,
                GreaterTan,
                LessThanOrEqualsTo,
                GreaterThanOrEqualsTo,
                NotEqualTo,
                IsNull
            }
        }
    }

    internal sealed class IncrementFilter: Filter
    {
        internal IncrementFilter()
        {

        }
    }
}
