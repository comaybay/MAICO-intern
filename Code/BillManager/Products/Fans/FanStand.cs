using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    class FanStand : Fan
    {
        public FanStand(string id, string name, string placeOfManufacture) : base(id, name, placeOfManufacture)
        {
        }

        public override string Type => "Quạt đứng";

        public override decimal Price => 500;
    }
}
