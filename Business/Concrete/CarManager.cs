using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
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

        public IResult Add(Car cars)
        {
            if (cars.CarName.Length <= 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _carDal.Add(cars);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            Console.WriteLine("Ürünler Marka Id'sine göre sıralandı.");
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            Console.WriteLine("Ürünler Renk Id'sine göre sıralandı.");
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        
    }
}
