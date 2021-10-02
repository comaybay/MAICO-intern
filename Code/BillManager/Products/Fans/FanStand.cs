using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    class FanStand : Fan
    {
        protected override decimal CalculatePrice() => 500;
    }
}
