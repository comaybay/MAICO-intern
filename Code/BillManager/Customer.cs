namespace BillManager
{
    public class Customer
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
    }
}