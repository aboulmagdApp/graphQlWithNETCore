namespace Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Orders {get; set;}
    }
}