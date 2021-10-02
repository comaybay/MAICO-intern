using BillManager.Models.Products;

namespace BillManager
{
    public class BillDetails
    {
        public Product Product { get; init; }

        public uint Quantity { get; init; }
    }
}