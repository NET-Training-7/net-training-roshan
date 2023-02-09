using System;
class Vehicle
{
     public Vehicle(string type,
        string model,
        string vendor,
        byte wheels,
        float mileage, 
        string vNumber)
        {
         this.type = type;
         this.model = model;
         this.vendor = vendor;
         this.nWheels = wheels;
         this.mileage = mileage;
         this.vNumber = vNumber;

        }
    internal string vendor;
    internal string vNumber;
    internal string model;
    internal string type;
    internal float mileage;
    internal byte nWheels;

    internal virtual void PrintDetails()
    {
        Console.Write($"It's {nWheels} wheeler {model} {type} from {vendor} and " +
            $"vehicle code is {vNumber}. " +
            $"This {type} has claimed mileage of {mileage} km/l.");
    }
}


