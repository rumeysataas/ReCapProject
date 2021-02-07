using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager cars = new CarManager(new EfCarDal());
            foreach (var car in cars.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("************************************************************");
            foreach (var car in cars.GetCarsByBrandId(5))
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in cars.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }
            cars.Add(new Car { CarID=8,BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 300,  Description="Mükemmel" });
        }
    }
}
