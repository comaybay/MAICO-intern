using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    class FanRechargeable : Fan
    {
        public FanRechargeable(string id, string name, string placeOfManufacture, float batteryCapacity)
            : base(id, name, placeOfManufacture)
        {
            BatteryCapacity = batteryCapacity;
        }

        public float BatteryCapacity { get; }

        public override decimal Price => (decimal)BatteryCapacity * 500;

        public override string Type => "Quạt sạc điện";

        public override IList<string> GetStringProps() => new List<string>(base.GetStringProps())
            {
                $"Dung lượng pin: {BatteryCapacity} Ah"
            };
    }
}
