using System;
class Person
{
   internal string name;
    internal byte age;

    public Person() //Default parameterless constructor(doesnot have return type)
    {
    }

    public Person(string n, byte a)
    {
        name = n;
        age = a;
    }
}

class Test2
{
 internal void T()
 {
    Person p1 = new();   // var p1 = new Person();
    p1.age = 23;
    p1.name = "Ram";
    Person p2 = new("Kishan", 67);
    Console.WriteLine($"{p1.name}, {p1.age}");
    Console.WriteLine($"{p2.name}, {p2.age}");

  
  }
  
  
}
