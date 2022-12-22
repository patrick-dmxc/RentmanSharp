using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Projects are the cornerstone of Rentman. Projects are connected to many other items. Projects always include one or more subprojects. When the user interface does not show any subprojects there is in fact a single one. See the /subprojects endpoint for more information.
    /// </summary>
    public class Projects : AbstractEndpoint<Project>
    {
        public override string Path { get => "projects"; }

        private static Pagination DEFAULT_PAGINATION = new Pagination(100);
        protected override Pagination? DefaultPagination => DEFAULT_PAGINATION;
    }
}