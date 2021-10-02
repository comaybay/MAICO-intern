using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.AirConditioners
{
    class AirConditionerTwoWay : AirConditioner
    {
        public bool AntimicrobialSupported { get; init; }

        public bool AirPurificationSupported { get; init; }

        protected override decimal CalculatePrice()
        {
            decimal price = 2000;

            if (InverterTechnologySupported)
                price += 500;

            if (AntimicrobialSupported)
                price += 500;

            if (AirPurificationSupported)
                price += 500;

            return price;
        }
    }
}
