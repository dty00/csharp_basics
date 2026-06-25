using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PaintStore.API.Database;
using PaintStore.API.DTOs;
using PaintStore.API.Migrations;
using PaintStore.Model;
using PaintStore.Model.Models;

namespace PaintStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly PaintStoreDbContext _dbContext;
    public OrdersController(PaintStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("CreateOrder")]
    public IActionResult CreateOrder([FromBody] OrderCreateDto orderCreateDto)
    {
        bool allProductExists = orderCreateDto.OrderItems.All(item => _dbContext.PaintProducts.Any(product => product.Id == item.PaintProductId));

        bool userExists = _dbContext.Users.Any(user => user.Id == orderCreateDto.UserId);

        if (allProductExists && userExists)
        {
            List<OrderItem> orderItems = new List<OrderItem>();


            foreach (OrderItemCreateDto orderItemCreate in orderCreateDto.OrderItems)
            {
                PaintProduct? paintProduct = _dbContext.PaintProducts.FirstOrDefault(product => product.Id == orderItemCreate.PaintProductId);

                OrderItem orderItem = new OrderItem(orderItemCreate.Quantity, orderItemCreate.PaintProductId,paintProduct.Price);

                orderItems.Add(orderItem);
            }

            Order order = new Order(orderCreateDto.UserId,orderItems);

            _dbContext.Add(order);
            _dbContext.SaveChanges();

            OrderResponseDto orderResponse = ToOrderResponseDto(order);


            return Created($"api/order/{order.Id}",orderResponse);
        }
        throw new Exception("No available products");
    }
    private static OrderResponseDto ToOrderResponseDto(Order order)
    {
        return new OrderResponseDto
        {
            CreatedDate = order.CreatedDate,
            UserId = order.UserId,
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            OrderItems = order.OrderItems.Select(item => new OrderItemResponseDto
            {
                PaintProductId = item.PaintProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            }).ToList()
        };
    }



    [HttpGet("GetAllOrders")]
    public IActionResult GetAllOrders(int pageNumber = 1, int pageSize = 10)
    {
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }
        if (pageSize < 1)
        {
            pageSize = 1;
        }

        List<Order> orders = _dbContext.Orders
        .OrderByDescending(o => o.CreatedDate)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

        return Ok(orders);
    }
    [HttpGet("GetOrdersByPriceRange")]
    public IActionResult GetOrdersByPriceRange(decimal minPrice = 0, decimal maxPrice = 1000)
    {
        List<Order> orders = _dbContext.Orders
        .Where(o =>
        o.OrderItems.Sum(item => item.Quantity * item.UnitPrice) >= minPrice &&
        o.OrderItems.Sum(item => item.Quantity * item.UnitPrice) <= maxPrice).ToList();
        return Ok(orders);
    }

    [HttpGet("GetOrdersByPaintId")]
    public IActionResult GetOrdersByPaintId(int id)
    {
        List<Order> orders = _dbContext.Orders
        .Where(order => order.OrderItems.Any(item => item.PaintProductId == id)).ToList();
        return Ok(orders);
    }

    [HttpGet("GetOrdersByUserId")]
    public IActionResult GetOrdersByUserId(int id)
    {
        List<Order> orders = _dbContext.Orders
        .Where(order => order.UserId == id).ToList();
        return Ok(orders);
    }

    [HttpGet("GetLastMonthOrders")]
    public IActionResult GetLastMonthOrders()
    {
        DateTime lastMonth = DateTime.Now.AddMonths(-1);
        List<Order> orders = _dbContext.Orders
        .Where(order => order.CreatedDate.Month == lastMonth.Month && order.CreatedDate.Year == lastMonth.Year).ToList();

        return Ok(orders);
    }

    [HttpGet("GetOrdersByDate")]
    public IActionResult GetOrdersByDate(DateTime date)
    {
        DateTime startOfDay = date.Date;
        DateTime startOfNextDay = startOfDay.AddDays(1);
        List<Order> orders = _dbContext.Orders
        .Where(order => order.CreatedDate.Date >= startOfDay && order.CreatedDate.Date < startOfNextDay).ToList();

        return Ok(orders);
    }

}

