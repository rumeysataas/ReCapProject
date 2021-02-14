using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from p in context.Rentals
                             join b in context.CarTbl
                             on p.CarId equals b.CarID
                             join r in context.Customers
                             on p.CustomerId equals r.Id
                             join v in context.Users
                             on r.UserId equals v.Id
                             select new RentalDetailDto
                             {
                                 CarName = b.CarName,
                                 FirstName=v.FirstName,
                                 LastName=v.LastName,
                                 RentDate=p.RentDate,
                                 ReturnDate=p.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
