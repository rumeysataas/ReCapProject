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
            CarAllMethod();
            //ColorAllMethod();
            //BrandAllMethod();
        }

        private static void BrandAllMethod()
        {
            BrandManager brand = new BrandManager(new EfBrandDal());
            brand.Add(new Brand { BrandName = "Mercedes" });
            brand.Delete(new Brand { BrandID = 2 });
            brand.Update(new Brand { BrandID = 1, BrandName = "Dacia" });
            foreach (var brands in brand.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }
            foreach (var brands in brand.GetById(1))
            {
                Console.WriteLine("**************************");
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void ColorAllMethod()
        {
            ColorManager color = new ColorManager(new EfColorDal());
            color.Add(new Color { ColorName = "Yellow" });
            color.Delete(new Color { ColorID = 4 });
            color.Update(new Color { ColorID = 5, ColorName = "Siyah" });
            foreach (var colors in color.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }
            foreach (var colors in color.GetById(2))
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void CarAllMethod()
        {
            CarManager cars = new CarManager(new EfCarDal());
            //foreach (var car in cars.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("************************************************************");
            //foreach (var car in cars.GetCarsByBrandId(5))
            //{
            //    Console.WriteLine(car.Description);
            //}
            //foreach (var car in cars.GetCarsByColorId(3))
            //{
            //    Console.WriteLine(car.Description);
            //}
            //cars.Add(new Car { CarName="Volkswagen 4TT 360",BrandId = 1, ColorId = 2, ModelYear = 2021, 
            //                    DailyPrice = 300, Description = "Deneme" 
            //                 });
            foreach (var car in cars.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }
    }
}
