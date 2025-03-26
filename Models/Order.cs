//namespace InventoryManagementAPI.Models
//{
//    public class Order
//    {
//    }
//}

namespace InventoryManagementAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
    }
}

