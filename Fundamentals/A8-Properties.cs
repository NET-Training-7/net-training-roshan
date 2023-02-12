using System;
public class Phone
{
    string brand;
    public string Brand
    {
        get
        {
            return brand;
        }
        set
        {
            if (value.Length > 1)
            {
                brand = value;
            }
        }
    }

    // public string model;
    DateTime releaseDate;
    public DateTime ReleaseDate
    {
        get
        {
            return releaseDate;
        }
        set
        {
            if (value < DateTime.Now)
            {
                releaseDate = value;
            }
        }
    }
    // Auto-implemented property
    public string Model { get; set; }
    // Read only property
    public string ChipManufacturer { get; }
    public static string material = "almunium";
    public static void PrintDetails()
    {
        Console.WriteLine($"It's all about phones. I am made of {material}");
    }

}