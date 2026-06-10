using sample.Enums;
using sample.Models;

// PaintType paintType = PaintType.BaseCoat;

// System.Console.WriteLine((int)paintType); //要数字
// System.Console.WriteLine(paintType); //要名字

// Paint paint = new Paint(paintType);
// PaintSpecification paintSpecification = new PaintSpecification("red",50);
// // paint.SetPrice(-1);
// // Console.WriteLine(paint.Price);
// paintSpecification.DisplaySpecification();

decimal TaxRate = 0.1m;

string name1 = "YouQiYiHao";
PaintType type1 = PaintType.BaseCoat;
PaintSpecification specification1 = new PaintSpecification("Blue",5);
decimal price1 = 40m;


string name2 = "YouQiErHao";
PaintType type2 = PaintType.Glossy;
PaintSpecification specification2 = new PaintSpecification("Red",6);
decimal price2 = 35.68m;


string name3 = "YouQiSanHao";
PaintType type3 = PaintType.Matte;
PaintSpecification specification3 = new PaintSpecification("Yellow",8);
decimal price3 = 20.58m;


PaintProduct paintProduct1 = new PaintProduct(name1, type1,  specification1,price1, TaxRate);

PaintProduct paintProduct2 = new PaintProduct(name2, type2,  specification2,price2, TaxRate);

PaintProduct paintProduct3 = new PaintProduct(name3, type3,  specification3,price3, TaxRate);

paintProduct1.DisplayInfo();

Order NewOrder = new Order(paintProduct1,10);
NewOrder.GetTotalPrice();
NewOrder.DisplayOrder();