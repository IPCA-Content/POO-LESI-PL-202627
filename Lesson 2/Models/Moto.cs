namespace Lesson_2.Models;

public class Moto : Vehicle
{
    public int NumberWheels { get; set; }
    
    public Moto(string brand, string model, int numberWheels)
    {
        Brand = brand;
        Model = model;
        NumberWheels = numberWheels;
    }
}