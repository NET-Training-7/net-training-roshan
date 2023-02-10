using System;
class Android : Mobile
{
    public Android(string brand, int price) : base(brand, price)
    {

    }

    internal int storage;
    internal void Details()
    {
        Console.WriteLine($"{brand} with {storage} space costs {price}.");
    }
}