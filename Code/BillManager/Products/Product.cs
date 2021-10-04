namespace BillManager.Products
{
    public abstract class Product
    {
        protected Product(string id, string name, string placeOfManufacture)
        {
            Id = id;
            Name = name;
            PlaceOfManufacture = placeOfManufacture;
        }
        public string Id { get; }

        public string Name { get; }

        public string PlaceOfManufacture { get; }

        public abstract decimal Price { get; }

        public abstract string Type { get; }
    }
}