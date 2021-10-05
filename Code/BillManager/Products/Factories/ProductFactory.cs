using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Factories
{
    abstract class ProductFactory
    {
        protected ProductFactory(IOHelper ioHelper)
        {
            IOHelper = ioHelper;
        }

        protected IOHelper IOHelper { get; }
        public abstract Product CreateProductThroughUserInput();

        protected (string id, string name, string placeOfManufacture) ReadInheritedProps()
        {
            string id = IOHelper.ReadNonEmptyString("Nhập mã sản phẩm: ");
            string name = IOHelper.ReadNonEmptyString("Tên sản phẩm: ");
            string placeOfManufacture = IOHelper.ReadNonEmptyString("Nơi sản xuất: ");

            return (id, name, placeOfManufacture);
        }
    }
}
