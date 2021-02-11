using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from p in context.CarTbl
                             join b in context.BrandTbl 
                             on p.BrandId equals b.BrandID
                             join c in context.ColorTbl
                             on p.ColorId equals c.ColorID
                             select new CarDetailDto
                             {
                                 CarName = p.CarName,
                                 ColorName = c.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
