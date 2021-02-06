using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //List tanımlamaları geri UI ya kullanıcıya isteği göstericeği için
        //Void ler sadece veri tabanında işlem yapıcak 
        List<Car> GetById(int id);
        List<Car> GetAll();
        void Add(Car cars);
        void Update(Car cars);
        void Delete(Car cars);
    }
}
