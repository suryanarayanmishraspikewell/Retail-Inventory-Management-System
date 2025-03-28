using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Models;

namespace InventoryManagementAPI.Services
{
    public interface IOrderService
    {
            Task<IEnumerable<Order>> GetAllOrders();
            Task<Order?> GetOrderById(int id);
            Task<Order> CreateOrder(OrderRequestDto order);
            Task UpdateOrder(Order order);
            Task DeleteOrder(int id);
       
    }
}
