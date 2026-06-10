using System;
using System.Runtime.InteropServices.Marshalling;
using sample.Enums;
using sample.Interfaces;

namespace sample.Models;

public class PaintProduct :IBuyable
{

    public PaintProduct(string name, PaintType type, PaintSpecification specification, decimal price, decimal taxRate)
    {
        Name = name;
        Type = type;
        Specification = specification;
        Price = price;
        TaxRate = taxRate;
    }
    public readonly decimal TaxRate = 0.1m;
    public const decimal DefaultDiscount = 0.05m;
    public string Name;
    public PaintType Type;
    public PaintSpecification Specification;
    public decimal Price;

    public void DisplayInfo()
    {
        Console.WriteLine($"The Product Name is {Name}, and the Type is {Type}");
    }

    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        if (isOverridable)
        {
            return rate;
        }

        return DefaultDiscount;

    }
        public decimal GetFinalPrice()
    {
        // decimal DiscountRate = GetMaxDiscount(rate,isOverridable);
        decimal DiscountedPrice = Price*(1-DefaultDiscount);
        decimal FinalPrice = DiscountedPrice*(1+TaxRate);
        return FinalPrice;
    }
}
