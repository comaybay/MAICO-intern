using BillManager.Products.Fans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Factories
{
    class FanFactory : ProductFactory
    {
        public FanFactory(IOHelper ioHelper) : base(ioHelper)
        {
        }

        public override Product CreateProductThroughUserInput()
        {
            IOHelper.IncreaseIndent();

            int choice = IOHelper.ReadIntWithCondition(
                "Chọn loại máy quạt (1-máy quạt đứng, 2-máy quạt hơi nước, 3–máy quạt sạc điện): ",
                (val) => val >= 1 && val <= 3
                );

            Product product = choice switch
            {
                1 => CreateFanStand(),
                2 => CreateFanMist(),
                3 => CreateFanRechargeable(),
                _ => throw new NotImplementedException(),
            };

            IOHelper.DecreaseIndent();

            return product;
        }

        private FanStand CreateFanStand()
        {
            (string id, string name, string placeOfManufacture) = ReadInheritedProps();
            return new FanStand(id, name, placeOfManufacture);
        }

        private FanMist CreateFanMist()
        {
            (string id, string name, string placeOfManufacture) = ReadInheritedProps();
            return new FanMist(
                id,
                name,
                placeOfManufacture,
                waterContainerCapacity: IOHelper.ReadNonNegativeFloat("Dung tích nước (đơn vị lít): ")
                );

        }

        private FanRechargeable CreateFanRechargeable()
        {
            (string id, string name, string placeOfManufacture) = ReadInheritedProps();
            return new FanRechargeable(
                id,
                name,
                placeOfManufacture,
                batteryCapacity: IOHelper.ReadNonNegativeFloat("Dung lượng pin (đơn vị Ah): ")
                );
        }

    }
}
