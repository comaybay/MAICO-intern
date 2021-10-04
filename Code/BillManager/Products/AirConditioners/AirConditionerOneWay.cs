using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.AirConditioners
{
    class AirConditionerOneWay : AirConditioner
    {
        public AirConditionerOneWay(string id, string name, string placeOfManufacture, bool inverterTechnologySupported)
            : base(id, name, placeOfManufacture, inverterTechnologySupported)
        {
        }

        public override string Type => "Máy lạnh một chiều";

        public override decimal Price => InverterTechnologySupported ? 1500 : 1000;
    }
}
