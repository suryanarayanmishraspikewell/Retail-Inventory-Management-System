using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;

namespace InventoryManagementAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<Order> CreateOrder(OrderRequestDto order)
        {
            var productDetail = await _productRepository.GetById(order.ProductId);

            if (order.Quantity > productDetail.Stock)
            {
                throw new InvalidOperationException($"Only {productDetail.Stock} products are available in stock.");
            }

            var newOrder = new Order
            {
                ProductId = order.ProductId,
                UserId = order.UserId,
                TotalPrice = order.Quantity*productDetail.Price,
                Status = "Delivered"
            };
            productDetail.Stock = productDetail.Stock - order.Quantity;
            await _productRepository.Update(productDetail);
            await _orderRepository.Add(newOrder);

            return newOrder;
        }

        public async Task UpdateOrder(Order order)
        {
            await _orderRepository.Update(order);
        }

        public async Task DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
        }
    }
}
