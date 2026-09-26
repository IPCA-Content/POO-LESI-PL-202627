namespace Lesson_2.Models;

public class Car : Vehicle
{
    public int NumberDoors { get; set; }
    
    public Car(string brand, string model, int numberDoors)
    {
        Brand = brand;
        Model = model;
        NumberDoors = numberDoors;
    }
}