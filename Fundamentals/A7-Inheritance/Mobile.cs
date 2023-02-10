using System;
class Mobile
{
    public Mobile(string brand,
    int price
    )
    {
        this.brand = brand;
        this.price = price;
    }

    internal string brand;
    internal int price;
    internal virtual void GetDetails()
    {
        Console.WriteLine($"{brand} costs {price}");
    }
}