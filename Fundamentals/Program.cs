using System;// See https://aka.ms/new-console-template for more information
//  class ABC
// {
//      public static void Main()
//     {
//         Test test = new();
//         test.Foo();
//     }
// }




    // Animal animal1 = new();
    // var animal2 = new Animal();
    // animal1.Name = "Lion";
    // animal1.Species = "Panthera leo";
    // animal1.Color = "Golden";
    // animal1.Age = 5;
    // animal1.DisplayDetails();

//  MethodsLearner m1 = new();
//  m1.Display();
//  m1.Display("Hi");
//  m1.Display("Welcome");

//  m1.Add(34.3f, 56.5f);

//  var s = m1.Greet();
//  Console.WriteLine(s);

//  var d = m1.GetDay();
//  Console.WriteLine(d);

//  float f = 12.3f, se = 45.6f, t = 67.12f;
//  var sum = m1.Add(f , se , t);
//  var tt = $"{f} + {se} + {t} = {sum}";
//  Console.WriteLine(tt);
// var p = m1.Multiply(22.22, 52.35, 25.32);
// var p1 = m1.Multiply(258.25, 2563.25);

// //named arguments 
// var p5 = m1.Multiply(z: 34.5, x: 67.7, y: 22.52);
Assignment r1 = new();
float r = r1.ProductOfSqaures(12.2f, 55.5f);
Console.WriteLine(r);

double s = r1.CubeRoot(555);
Console.WriteLine(s);

float t = r1.CalculateBmiIndex(60f, 5.8f);
Console.WriteLine($"Your BMI index is {t}");