using System;
using System.ComponentModel.DataAnnotations;
using PaintStore.Model.Enums;

namespace PaintStore.API.DTOs;

public class PaintCreateDto
{
    [Range(0,88888)]
    public decimal Price {get;set;}

    public PaintType PaintType {get; set;}

    public string Name { get; set; } = string.Empty;
}
