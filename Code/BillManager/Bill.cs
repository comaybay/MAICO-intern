using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    class Bill
    {
        public string ID { get; init; }

        public Customer Customer { get; init; }

        public IEnumerable<BillDetails> BillDetailsList { get; init; }

        public DateTime DateCreated { get; init; }

        private decimal _totalPrice;
        public decimal TotalPrice { get => _totalPrice; }

        public Bill()
        {
            _totalPrice = BillDetailsList.Select(details => details.Product.Price * details.Quantity)
                                         .Sum();
        }
    }
}