using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        //ICustomerDal _customerDal;

        //public RentalManager(ICustomerDal customerDal)
        //{
        //    _customerDal = customerDal;
        //}

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
      

        public IResult Add(Rental rental)
        {
            CustomerManager user = new CustomerManager(new EfCustomerDal());
            foreach (var users in user.GetAll().Data)
            {
                if (rental.CustomerId == users.Id)
                {
                    foreach (var item in _rentalDal.GetAll(p => p.CarId == rental.CarId))
                    {
                        if (item != null && item.ReturnDate == null)
                        {
                            Console.WriteLine("ELinizdeki arabayı teslim ettikten sonra yeni araba kiralayabilirsiniz");
                            return new SuccessResult(Messages.ProductAdded);
                        }
                        else
                        {

                        }
                    }

                    Console.WriteLine("Ürününüz Başarıyla Eklendi");
                        return new SuccessResult(Messages.ProductAdded);
                    }
            }
            Console.WriteLine("Ürününüz Eklenemedi");
            return new SuccessResult(Messages.ProductNotAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p=>p.Id==id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
//IDataResult<List<Rental>> GetNullId()
//{
//    return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.ReturnDate == null));
//}
//if (GetNullId()==null)
//{
//    _rentalDal.Add(rental);
//    Console.WriteLine("Ürününüz Başarıyla Eklendi");
//    return new SuccessResult(Messages.ProductAdded);
//}
//else
//{
//    Console.WriteLine("ELinizdeki arabayı teslim ettikten sonra ");
//    return new SuccessResult(Messages.ProductAdded);
//}
//foreach (var item in _rentalDal.GetAll(p => p.CustomerId == rental.CustomerId))
//{
//    if (item != null && item.ReturnDate == null)
//    {
//        Console.WriteLine("ELinizdeki arabayı teslim ettikten sonra yeni araba kiralayabilirsiniz");
//        return new SuccessResult(Messages.ProductAdded);
//    }
//    else
//    {

//    }
//}
