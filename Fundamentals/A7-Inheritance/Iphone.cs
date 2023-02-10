using System;
class Iphone : Mobile
{
    public Iphone(string brand, int price) : base(brand, price)
    {

    }
    internal override void GetDetails()
    {
        base.GetDetails();
        Console.WriteLine("iphone");
    }
}