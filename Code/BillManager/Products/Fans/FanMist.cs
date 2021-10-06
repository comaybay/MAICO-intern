using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    class FanMist : Fan
    {
        public FanMist(string id, string name, string placeOfManufacture, float waterContainerCapacity)
            : base(id, name, placeOfManufacture)
        {
            if (waterContainerCapacity < 0)
                throw new ArgumentException("WaterContainerCapacity cannot be set to a negative value.");

            WaterContainerCapacity = waterContainerCapacity;
        }

        public float WaterContainerCapacity { get; }

        public override decimal Price => (decimal)WaterContainerCapacity * 400;

        public override string Type => "Quạt hơi nước";

        public override IList<string> GetStringProps() => new List<string>(base.GetStringProps())
            {
                $"Dung tích nước: {WaterContainerCapacity} lít"
            };

        public override string GetPropValuesAsSingleString() => $"{base.GetPropValuesAsSingleString()} {WaterContainerCapacity}";
    }
}
