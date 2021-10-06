using System.Collections.Generic;

namespace BillManager
{
    public class Customer : IStringConvertable
    {
        public Customer(string id, string name, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string Id { get; }

        public string Name { get; }

        public string PhoneNumber { get; }

        public string Address { get; }

        public IList<string> GetStringProps() => new List<string>()
            {
                $"Mã khách hàng: {Id}",
                $"Tên khách hàng: {Name}",
                $"Số điện thoại: {PhoneNumber}",
                $"Địa chỉ: {Address}"
            };

        public string GetPropValuesAsSingleString()
        {
            throw new System.NotImplementedException();
        }
    }
}