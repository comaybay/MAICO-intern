using BillManager.Products;

namespace BillManager
{
    public class BillDetails
    {
        public BillDetails(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }

        public int Quantity { get; }
    }
}