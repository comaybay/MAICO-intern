using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    abstract class Fan : Product
    {
        protected Fan(string id, string name, string placeOfManufacture) : base(id, name, placeOfManufacture)
        {
        }

        public override string GetPropValuesAsSingleString() => $"Máy quạt: {base.GetPropValuesAsSingleString()}";
    }
}
