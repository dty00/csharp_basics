using System;
using System.Security.Cryptography.X509Certificates;

namespace sample.Models;

public class Order
{

    public readonly DateTime OrderTime;
    public PaintProduct Product {get; set;}
    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
    public Order(PaintProduct paintProduct, int quantity)
    {
        OrderTime = DateTime.Now;
        Product = paintProduct;
        Quantity = quantity;
        TotalPrice = GetTotalPrice();
        
    }

    public decimal GetTotalPrice()
    {
        decimal TotalPrice = Product.Price*Quantity;
        return TotalPrice;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"This order contains {Product.Name}, the total price is {TotalPrice}");
    }
}
