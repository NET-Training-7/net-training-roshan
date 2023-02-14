using System;
using System.Linq;
class LINQ
{ 
    int[] scores = { 3, 4, 5, 6, 7, 8, 9, 10, 55, 56, 57, 58};
    public void LearnToQuery()
    {
        var oddNumbers = scores.Where(s => s % 2 != 0);
        foreach(var num in oddNumbers)
        {
            Console.Write($"{num} ");
        }
    }
}