namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// All user-generated documents and uploaded files are available in this endpoint. Files are always linked to at least one other item. There are two types of links. The file_item and file_itemtype describe the item where the file originates from, for example a quotation or an import. If a file is attached in the user interface to another item, e.g. a project or an equipment item, this is done using the item and itemtype field. Due to syncing limitations, it can take a day for files to become available in the Rentman API. Syncing files happens every 24 hours.
    /// </summary>
    public class Files : AbstractEndpoint<Entity.File>
    {
        public override string Path { get => "files"; }

        private static Pagination DEFAULT_PAGINATION = new Pagination(100);
        protected override Pagination? DefaultPagination => DEFAULT_PAGINATION;
    }
}