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

        public override IList<string> GetStringProps() => new List<string>(base.GetStringProps())
            {
                $"Hỗ trợ công nghệ khử mùi: {(AirPurificationSupported ? "Có" : "Không")}",
                $"Hỗ trợ công nghệ kháng khuẩn: {(AntimicrobialSupported ? "Có" : "Không")}"
            };

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
