using System;
class MethodsLearner
{
// method that returns nothing, takes no arguments
internal void Display()
{
 Console.WriteLine("Hello guys, I am simplest possible method in C#.");
}
//returns nothing, takes some arguments
// method overloading (polymorohism - OOP)
internal void Display(string greeting)
{
    Console.WriteLine(greeting + " guys, I am simplest possible method in C#.");
    // Console.WriteLine($"{greeting} guys, I am simplest possible method in C#.");
}
public void Add(float first, float second)
{
    float sum = first + second;
    string dText = $"{first} + {second} = {sum}"; // string interpolation 
    Console.WriteLine(dText);
    // Console.WriteLine(first + " + " + second + " = " + sum); // 3 + 7 = 10
}

// Returns something, takes no arguments
public string Greet()
{
    string text = "Hi guys, I am simplest possible method in C#.";
    return text;
}

public string GetDay()
{
    var d = DateTime.Today.DayOfWeek.ToString();
    string today = $"It's {d}";
    return today;
}

//returns something, takes some arguments 
public float Add(float first, float second, float third)
{
    float sum = first + second + third;
    return sum;
}
// optional parameters, variable number of arguments 
public double Multiply(double x, double y, double z = 1)
{
var product = x * y * z; // Multiplicand * Multiper
return product;
}
// expression bodied members
public float Divide(float first, float second) => first / second;

// write a method to calculate minimum among supplied numbers


}




