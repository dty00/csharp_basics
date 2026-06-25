using System;
using System.ComponentModel.DataAnnotations;
using PaintStore.Model;

namespace PaintStore.API.DTOs;

public class OrderCreateDto
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public List<OrderItemCreateDto> OrderItems {get; set;}
}
