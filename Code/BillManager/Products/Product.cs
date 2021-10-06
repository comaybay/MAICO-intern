using System.Collections.Generic;

namespace BillManager.Products
{
    public abstract class Product : IStringConvertable
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

        public virtual IList<string> GetStringProps()
        {
            return new List<string>()
            {
                $"Mã sản phẩm: {Id}",
                $"Loại sản phẩm: {Type}",
                $"Tên sản phẩm: {Name}",
                $"Nơi sản xuất: {PlaceOfManufacture}",
                $"Đơn giá: {Price} nghìn vnđ",
            };
        }
        public virtual string GetPropValuesAsSingleString() => $"{Id} {Type} {Name} {PlaceOfManufacture} {Price}";
    }
}