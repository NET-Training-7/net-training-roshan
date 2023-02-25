using System;
using System.IO;
namespace IO;
class FDHandling
{
    public void LearnFiles()
    {
        //Create new file
        var rootFolder = @"D:\net training\net-training-roshan\Fundamentals\FDHandling";
        var filePath = $"{rootFolder}\\firstFile.txt";
        File.WriteAllText(filePath, "Nepal is beautiful country. Please visit us.");
        Console.WriteLine("File created successfully. ");

        var folderPath = $"{rootFolder}\\Nepal";
        Directory.CreateDirectory(folderPath);
        Console.WriteLine("Folder created successfully.");

        //Create a text file "countries.txt" with at least of 5 country names
        var countryNames = $"{rootFolder}\\countries.txt";
        File.WriteAllText(countryNames, "Nepal, Australia, USA, Canada, India ");
        Console.WriteLine("Countries file created successfully.");
        
    }

    public void LearnMore()
    {
        var filePath = @"D:\net training\net-training-roshan\Fundamentals\FDHandling\PlayingGod.txt";
        string content = File.ReadAllText(filePath);
        // Console.WriteLine(content);

        //Find following for above file content
        // - No. of sentences and their list 
        // - No. of words and their list 
        // - No. of characters and their list 
        // - No. of special characters and their list 
        // char[] separators 
        // string[] parts = content.Split(",");
    }
}