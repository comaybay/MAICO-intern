using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.AirConditioners
{
    class AirConditionerOneWay : AirConditioner
    {
        protected override decimal CalculatePrice() => InverterTechnologySupported ? 1500 : 1000;
    }
}
