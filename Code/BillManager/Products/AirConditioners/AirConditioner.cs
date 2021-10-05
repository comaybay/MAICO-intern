﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.AirConditioners
{
    abstract class AirConditioner : Product
    {
        protected AirConditioner(string id, string name, string placeOfManufacture, bool inverterTechnologySupported)
            : base(id, name, placeOfManufacture)
        {
            InverterTechnologySupported = inverterTechnologySupported;
        }

        public bool InverterTechnologySupported { get; }
    }
}