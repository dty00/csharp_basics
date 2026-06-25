using System;

namespace PaintStore.API.DTOs;

public class OrderItemResponseDto
{
    public int PaintProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
