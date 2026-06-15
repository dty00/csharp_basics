using System;
using System.Security.Cryptography.X509Certificates;
using sample.Enums;

namespace sample.Models;

public class Order
{

    public readonly DateTime OrderTime;
    public List<PaintProduct> Products {get; set;}
    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
    public Order(List<PaintProduct> products, int quantity)
    {
        OrderTime = DateTime.Now;
        Products = products;
        Quantity = quantity;
        TotalPrice = GetTotalPrice();
        
    }
    
    public decimal GetTotalPrice()
    {
        decimal TotalPrice = Products.Sum(p =>p.Price);
        return TotalPrice;
    }

    public void GetMostExpensivePaintProduct()
    {
        var MostExpensivePaintProduct = Products.OrderByDescending(p =>p.Price).FirstOrDefault();
        Console.WriteLine(MostExpensivePaintProduct?.Name);
    }

    public void RemoveProduct(int productId)
    {
        Products.RemoveAll(p => p.Id == productId);
    }

    public List<PaintProduct> FindRangeFromToPaintProduct(decimal lowerPrice, decimal higherPrice)
    {
        var rangeProducts = Products.Where(p => p.Price > lowerPrice && p.Price < higherPrice).ToList();
        return  rangeProducts;
    }

    public decimal GetSameCategoryPaintPrice(PaintType type)
    {
        decimal CategoryPrice = Products.Where(p => p.Type == type).Sum(p =>p.Price);
        return CategoryPrice;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"This order contains {Products.Count()}, the total price is {TotalPrice}");
    }
}
