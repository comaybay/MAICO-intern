using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    class FanRechargeable : Fan
    {
        public uint BatteryCapacity { get; init; }

        protected override decimal CalculatePrice() => BatteryCapacity * 500;
    }
}
