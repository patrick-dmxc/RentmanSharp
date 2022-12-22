using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Stock movements are all the changes that happen to the stock levels of an equipment. Those changes include manual changes, purchases, sales, transfers, stock corrections, repairs, marking lost or found, imports, stock counts. When creating or updating stock movements via the API only stock movements of type 'manual' are writable. Only stock movements for bulk items are available though the API. Stock movements for serialized equipment may be implemented at a later stage.
    /// </summary>
    public class StockMovements : AbstractEndpoint<StockMovement>
    {
        public override string Path { get => "stockmovements"; }
    }
}