using System;
using sample.Enums;
using sample.Interfaces;

namespace sample.Models;

public class Paint : IProduct
{
    //成员1: 状态 -----> properties  C# 特有的功能
    // int price;
    // string name;

    // public Paint()
    // {
    //     PaintType = PaintType.Unknown;
    // }
    public Paint(PaintType paintType)
    {
        // PaintType = PaintType.Basic; //hard code to basic
        PaintType = paintType; 
    }
    public decimal Price {get; private set;}
    public PaintType PaintType { get; set; }

    public decimal CalculatePrice()
    {
        return Price;
    }

    //成员2: 行为
    public void SetPrice(decimal value)
    {   
        if(value <= 0)
        {
            throw new Exception("Value is invalid");
        }
        Price = value;
    }

}
