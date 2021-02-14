using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCustomerDal :EfEntityRepositoryBase<Customer,ReCapContext>,ICustomerDal
    {

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from p in context.Customers
                             join b in context.Users
                             on p.UserId equals b.Id
                             select new CustomerDetailDto
                             {
                                CompanyName=p.CompanyName,
                                FirstName=b.FirstName,
                                LastName=b.LastName
                             };
                return result.ToList();
            }
        }
    }
}
