using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// All equipment.
    /// </summary>
    public class Equipment : AbstractEndpoint<EquipmentItem>
    {
        public override string Path { get => "equipment"; }

        private static Pagination DEFAULT_PAGINATION = new Pagination(100);
        protected override Pagination? DefaultPagination => DEFAULT_PAGINATION;
    }
}