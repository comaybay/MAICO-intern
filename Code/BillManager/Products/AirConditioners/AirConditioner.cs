using BillManager.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.AirConditioners
{
    abstract class AirConditioner : Product
    {
        public bool InverterTechnologySupported { get; init; }
    }
}
