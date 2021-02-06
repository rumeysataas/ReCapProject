using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
             {
                 new Car{Id=1,BrandId=1,ColorId=3,ModelYear=1996,DailyPrice=250.00,Description="Temiz"},
                 new Car{Id=2,BrandId=5,ColorId=3,ModelYear=2005,DailyPrice=500.00,Description="Güzel"},
                 new Car{Id=3,BrandId=3,ColorId=2,ModelYear=1998,DailyPrice=300.00,Description="Hızlı"},
                 new Car{Id=4,BrandId=2,ColorId=4,ModelYear=2020,DailyPrice=1000.00,Description="Geniş"},
                 new Car{Id=5,BrandId=4,ColorId=1,ModelYear=2004,DailyPrice=700.00,Description="Conforlu"}
             }; 
        }

        public void Add(Car cars)
        {
            _car.Add(cars);
            Console.WriteLine("Yeni araba Bilgileri Eklendi");
        }

        public void Delete(Car cars)
        {
            Car delete = _car.SingleOrDefault(p => p.Id == cars.Id);
            _car.Remove(delete);
            Console.WriteLine("Araba Bilgileri Silindi");
        }

        public List<Car> GetAll()
        {
            return _car;
            
        }

        public List<Car> GetById(int id)
        {

            return _car.Where(p => p.Id == id).ToList();
        }

        public void Update(Car cars)
        {
            Car update = _car.SingleOrDefault(p => p.Id == cars.Id);
            update.BrandId = cars.BrandId;
            update.ColorId = cars.ColorId;
            update.ModelYear = cars.ModelYear;
            update.DailyPrice = cars.DailyPrice;
            update.Description = cars.Description;
            Console.WriteLine("Araba Bilgileri Güncellendi.");
        }
    }
}
