using System;
using PaintStore.Model.Enums;
using PaintStore.Model.Interfaces;

namespace PaintStore.Model;

public class PaintProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public PaintType PaintType { get; set; }
    public PaintProduct()
    {
        
    }
    public PaintProduct(string name, decimal price, PaintType paintType)
    {
        Name = name;
        Price = price;
        PaintType = paintType;
    }

    public decimal CalculatePrice()
    {
        return Price;
    }


}
