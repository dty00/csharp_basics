using System;

namespace PaintStore.Model.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int Quantity { get; set; }
    public int PaintProductId { get; set; }
    public PaintProduct PaintProduct { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice => Quantity * UnitPrice ;

    public OrderItem(int quantity, int paintProductId, decimal unitPrice)
    {
        Quantity = quantity;
        PaintProductId = paintProductId;
        UnitPrice = unitPrice;
    }
    public OrderItem()
    {
    }

}
