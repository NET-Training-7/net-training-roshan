using System;
class Assignment
{
    internal float ProductOfSqaures(float first, float second)
    {
        float square = (first * first) * (second * second);
        return square;
    }
// internal float ProductOfSquares(float first, float second) => (first * first) * (second * second);
    internal double CubeRoot(double x)
    {
        double cube = Math.Pow(x, 1.0 / 3.0);
        return cube;
    }

    internal float CalculateBmiIndex(float weightInKg, float heightInFeet)
    {
        float heightInMeters = heightInFeet * 0.3048f;
        float bmi = weightInKg / (heightInMeters * heightInMeters);
        return bmi;
    }
}
