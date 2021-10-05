using BillManager.Products.AirConditioners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Factories
{
    class AirConditionerFactory : ProductFactory
    {
        public AirConditionerFactory(IOHelper ioHelper) : base(ioHelper)
        {
        }

        public override Product CreateProductThroughUserInput()
        {
            IOHelper.IncreaseIndent();

            int choice = IOHelper.ReadIntWithCondition(
             "Chọn loại máy lạnh (1-máy lạnh một chiều, 2-máy lạnh hai chiều): ",
             (val) => val >= 1 && val <= 2
             );

            Product product = choice switch
            {
                1 => CreateACOneWay(),
                2 => CreateACTwoWay(),
                _ => throw new NotImplementedException(),
            };

            IOHelper.DecreaseIndent();

            return product;
        }

        private AirConditionerOneWay CreateACOneWay()
        {
            (string id, string name, string placeOfManufacture) = ReadInheritedProps();
            return new AirConditionerOneWay(
                id,
                name,
                placeOfManufacture,
                inverterTechnologySupported: IOHelper.ReadBoolean("Có hỗ trợ công nghệ inverter? (0-không, 1-có): ")
                );
        }

        private AirConditionerTwoWay CreateACTwoWay()
        {
            (string id, string name, string placeOfManufacture) = ReadInheritedProps();
            return new AirConditionerTwoWay(
                id,
                name,
                placeOfManufacture,
                inverterTechnologySupported: IOHelper.ReadBoolean("Có hỗ trợ công nghệ inverter? (0-không, 1-có): "),
                airPurificationSupported: IOHelper.ReadBoolean("Có hỗ trợ công nghệ khử mùi? (0-không, 1-có): "),
                antimicrobialSupported: IOHelper.ReadBoolean("Có hỗ trợ công nghệ kháng khuẩn? (0-không, 1-có): ")
                );
        }
    }
}
