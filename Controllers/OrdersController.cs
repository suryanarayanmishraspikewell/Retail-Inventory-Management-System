//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace InventoryManagementAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//    }
//}

using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderService _orderService;

        public OrdersController(IRepository<Order> orderRepository, IOrderService orderservice)
        {
            _orderRepository = orderRepository;
            _orderService = orderservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _orderRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderRequestDto order)
        {
            try
            {
                //await _orderRepository.Add(order);
                var newOrder = await _orderService.CreateOrder(order);
                return CreatedAtAction(nameof(GetOrder), new { id = newOrder.OrderId }, newOrder);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            catch (Exception ex) {
                return StatusCode(500, new {message = ex.Message});
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId) return BadRequest();
            await _orderRepository.Update(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
            return NoContent();
        }
    }
}