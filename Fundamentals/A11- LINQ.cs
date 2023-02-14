using System;
using System.Linq;
class LINQ
{ 
    int[] scores = { 3, 4, 5, 6, 7, 8, 9, 10, 55, 56, 57, 58};
    public void LearnToQuery()
    {
        var oddNumbers = scores.Where(s => s % 2 != 0);
        
        var cubesBetween50and70 = scores.Where(s => s >= 50 && s<=70).Select(s => s * s * s);

        cubesBetween50and70 = from s in scores
                              where s >= 50 && s<= 70
                              select s * s * s;

        var squareRoot = scores.Where(s => s % 10 == 0).Select(s => Math.Sqrt(s));                     

        foreach(var num in oddNumbers)
        {
            Console.Write($"{num} ");
        }
    }
}