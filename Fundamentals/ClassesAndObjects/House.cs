using System;

class House
{
    internal string address; // access modifiers: private, public, internal, protected default:private
    internal float length;
    internal float width;
    internal float area;

    internal void GetArea()
    {
        area = length * width;
    }


}

class Test
{
    internal void Foo()
    {
        House house1 = new();
        var house2 = new House();

        house1.address = "Tinkune, ktm";
        house1.length = 45.6f;
        house1.width = 25.3f;
        house1.GetArea();
        Console.WriteLine(house1.area);
    }
}