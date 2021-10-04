using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.AirConditioners
{
    class AirConditionerTwoWay : AirConditioner
    {
        public AirConditionerTwoWay(
            string id, string name, string placeOfManufacture,
            bool inverterTechnologySupported, bool antimicrobialSupported, bool airPurificationSupported
            )
            : base(id, name, placeOfManufacture, inverterTechnologySupported)
        {
            AntimicrobialSupported = antimicrobialSupported;
            AirPurificationSupported = airPurificationSupported;

            Price = CalculatePrice();
        }

        public bool AirPurificationSupported { get; }

        public bool AntimicrobialSupported { get; }

        public override decimal Price { get; }

        public override string Type => "Máy lạnh hai chiều";

        protected decimal CalculatePrice()
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
