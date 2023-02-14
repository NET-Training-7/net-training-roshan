// LINQ - Language Integrated Query
// Technique to query collections (array, list, dictionaries etc)
using System;
using System.Linq;
class LINQ
{
    int[] scores = { 3, 4, 5, 6, 7, 8, 9, 10, 55, 56, 57, 58 };

    string[] names = { "Elon Musk", "Balen Shah", "Leo Messi", "Neymar Jr" };
    public void LearnToQuery()
    {
        // Q1. Find all even numbers from scores
        // Method syntax
        var evenNumbers = scores.Where(s => s % 2 == 0);

        // Expression syntax
        evenNumbers = from s in scores
                      where s % 2 == 0
                      select s;

        // Q2. Find all odd numbers from scores             
        var oddNumbers = scores.Where(s => s % 2 != 0);

        // Q3. Find multiples of 3 and 5 from scores
        var multiplesOf3And5 = scores.Where(s => s % 3 == 0 && s % 5 == 0);

        // Q4. Find squares of all numbers in scores
        var squares = scores.Select(s => s * s);

        // Q5. Find squares of all numbers which are less than 50 from scores
        var squaresLessThan50 = scores.Where(s => s < 50).Select(s => s * s);

        squaresLessThan50 = from s in scores
                            where s < 50
                            select s * s;

        // Q6. Find cubes of all numbers in between 50 and 70 from scores
        var cubesBetween50and70 = scores.Where(s => s >= 50 && s <= 70).Select(s => s * s * s);

        cubesBetween50and70 = from s in scores
                              where s >= 50 && s <= 70
                              select s * s * s;

        // Q7. Find square roots of all numbers ending in 0 from score                     
        var squareRoot = scores.Where(s => s % 10 == 0).Select(s => Math.Sqrt(s));

        // Q8. Get uppercase equivalent of all names and sort them in ascending order
        var uNames = from name in names
                     orderby name
                     select name.ToUpper();

        uNames = names.Select(n => n.ToUpper()).OrderBy(n => n);
        foreach (var num in oddNumbers)
        {
            Console.Write($"{num} ");
        }
    }
}