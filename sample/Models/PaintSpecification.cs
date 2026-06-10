using System;

namespace sample.Models;

public class PaintSpecification
{

    public PaintSpecification(string color, int sizeinliters)
    {
        Color = color;
        SizeInLiters = sizeinliters;
    }
    public string Color;
    public int SizeInLiters;

    public void DisplaySpecification()
    {
        Console.WriteLine(Color,SizeInLiters);
    }


}
