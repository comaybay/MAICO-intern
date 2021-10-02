using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    class FanMist : Fan
    {
        private float _waterContainerCapacity;

        public float WaterContainerCapacity
        {
            get => _waterContainerCapacity;
            init
            {
                if (_waterContainerCapacity < 0)
                    throw new ArgumentException("WaterContainerCapacity cannot be set to a negative value.");

                _waterContainerCapacity = value;
            }
        }

        protected override decimal CalculatePrice() => (decimal)WaterContainerCapacity * 400;
    }
}
