using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace PaintStore.API.DTOs;

public class OrderItemCreateDto
{
    [Required]
    [Range(1,100)]
    public int Quantity { get; set; }

    [Required]
    public int PaintProductId { get; set; }

}
