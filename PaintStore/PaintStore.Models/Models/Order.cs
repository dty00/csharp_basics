using System;
using PaintStore.Model.Models;

namespace PaintStore.Model;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; private set; }
    public User User { get; set; } = null!;
    public int UserId { get; set; }

    // public List<PaintProduct> PaintProducts { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public Order()
    {
        CreatedDate = DateTime.Now;
        OrderItems = new List<OrderItem>();

    }

    // public decimal TotalPrice => PaintProducts.Sum(paint =>paint.Price);

    public decimal TotalPrice => OrderItems.Sum(order => order.TotalPrice);


}
