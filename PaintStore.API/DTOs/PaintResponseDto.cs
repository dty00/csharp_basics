using System;
using PaintStore.Model.Enums;

namespace PaintStore.API.DTOs;

public class PaintResponseDto
{
    public decimal Price { get; set; }

    public PaintType PaintType { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Id { get; set; }
}
