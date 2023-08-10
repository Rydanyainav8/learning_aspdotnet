namespace learning_aspdotnet.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string AddressLine1 { get; set; } = string.Empty;   

        public string? AddressLine2 { get; set;}

        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string? State { get; set; }

        public string Country { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set ; } = string.Empty;

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}
