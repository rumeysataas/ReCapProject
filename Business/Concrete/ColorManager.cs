using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        { 
             if (color.ColorName.Length <= 2)
             {
                return new ErrorResult(Messages.ProductNameInvalid);
             }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
    
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new  SuccessDataResult<List<Color>>( _colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetById(int Id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorID == Id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
