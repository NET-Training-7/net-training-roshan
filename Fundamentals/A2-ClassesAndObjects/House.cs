using System;

internal class House
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

