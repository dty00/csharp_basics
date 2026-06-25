using System;

namespace PaintStore.API.DTOs;

public class OrderResponseDto
{
       
    public int UserId { get; set; }
    public int Id {get; set;}
    
    public List<OrderItemResponseDto> OrderItems { get; set; } = [];

    public decimal TotalPrice {get; set;}

    public DateTime CreatedDate {get; set;}
}
