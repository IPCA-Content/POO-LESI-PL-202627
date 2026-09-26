//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>21-09-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_2.Models;

namespace Lesson_2
{
    /// <summary>
    /// Class program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Car car = new Car("Toyota", "Corolla", 4);
            Console.WriteLine($"Car Brand: {car.Brand}");
            
            Moto moto = new Moto("Honda", "CBR500R", 2);
            
            Console.WriteLine($"Moto Brand: {moto.Brand}");
            Console.WriteLine($"Moto Number of Wheels: {moto.NumberWheels}");
        }
    }
}