//namespace InventoryManagementAPI.Models
//{
//    public class User
//    {
//    }
//}


namespace InventoryManagementAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }
    }
}
