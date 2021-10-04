using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    class Bill
    {
        public Bill(string id, DateTime dateCreated, Customer customer, IList<BillDetails> billDetailsList)
        {
            Id = id;
            Customer = customer;
            BillDetailsList = billDetailsList;
            DateCreated = dateCreated;

            TotalPrice = BillDetailsList.Select(details => details.Product.Price * details.Quantity)
                                         .Sum();
        }

        public string Id { get; }

        public Customer Customer { get; }

        public IList<BillDetails> BillDetailsList { get; }

        public DateTime DateCreated { get; }

        public decimal TotalPrice { get; }
    }
}