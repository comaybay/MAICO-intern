namespace BillManager.Models.Products
{
    public abstract class Product
    {
        public string Name { get; init; }

        public string PlaceOfManufacture { get; init; }

        public decimal Price { get => CalculatePrice(); }

        protected abstract decimal CalculatePrice();
    }
}