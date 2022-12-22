using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Represents a company or a private person.
    /// </summary>
    public class Contacts : AbstractEndpoint<Contact>
    {
        public override string Path { get => "contacts"; }

        private static Pagination DEFAULT_PAGINATION = new Pagination(100);
        protected override Pagination? DefaultPagination => DEFAULT_PAGINATION;
    }
}