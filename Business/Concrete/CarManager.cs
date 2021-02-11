using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       
        public void Add(Car cars)
        {
            if (cars.DailyPrice > 0 && cars.CarName.Length >= 2)
            {
                _carDal.Add(cars);
                Console.WriteLine("Ürününüz başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Eklediğiniz ürün şartlara uymamaktadır.");
            }
        }

       

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            Console.WriteLine("Ürünler Marka Id'sine göre sıralandı.");
            return _carDal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            Console.WriteLine("Ürünler Renk Id'sine göre sıralandı.");
            return _carDal.GetAll(p => p.ColorId == id);
        }

        
    }
}
