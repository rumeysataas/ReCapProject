using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                 new Car{CarID=1,BrandId=1,ColorId=3,ModelYear=1996,DailyPrice=25000,Description="Temiz"},
                 new Car{CarID=2,BrandId=5,ColorId=3,ModelYear=2005,DailyPrice=50000,Description="Güzel"},
                 new Car{CarID=3,BrandId=3,ColorId=2,ModelYear=1998,DailyPrice=30000,Description="Hızlı"},
                 new Car{CarID=4,BrandId=2,ColorId=4,ModelYear=2020,DailyPrice=100000,Description="Geniş"},
                 new Car{CarID=5,BrandId=4,ColorId=1,ModelYear=2004,DailyPrice=70000,Description="Conforlu"}
             }; 
        }

        public void Add(Car cars)
        {
            _car.Add(cars);
            Console.WriteLine("Yeni araba Bilgileri Eklendi");
        }

        public void Delete(Car cars)
        {
            Car delete = _car.SingleOrDefault(p => p.CarID == cars.CarID);
            _car.Remove(delete);
            Console.WriteLine("Araba Bilgileri Silindi");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {

            return _car.Where(p => p.CarID == id).ToList();
        }

        public void Update(Car cars)
        {
            Car update = _car.SingleOrDefault(p => p.CarID == cars.CarID);
            update.BrandId = cars.BrandId;
            update.ColorId = cars.ColorId;
            update.ModelYear = cars.ModelYear;
            update.DailyPrice = cars.DailyPrice;
            update.Description = cars.Description;
            Console.WriteLine("Araba Bilgileri Güncellendi.");
        }
    }
}
