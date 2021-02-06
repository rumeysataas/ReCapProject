using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager cars = new CarManager(new InMemoryCarDal());
            
            cars.Add(new Car{ Id = 6, BrandId = 4, ColorId = 2, ModelYear = 1999 ,DailyPrice=290.00,Description="Uygun Fiyat"});
            cars.GetAll();
            
        }
    }
}
