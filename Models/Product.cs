//namespace InventoryManagementAPI.Models
//{
//    public class Product
//    {
//    }
//}


namespace InventoryManagementAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
