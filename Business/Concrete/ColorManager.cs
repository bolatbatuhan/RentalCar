using Business.Abstract;
using Business.Constans;
using CorePackages.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public IResult Add(Color color)
    {
        if(color.Name.Length < 2 )
        {
            return new ErrorResult(Messages.ColorNameMustBeBiggerThanTwo);
        }
        _colorDal.Add(color);
        return new SuccessResult(Messages.ColorAdded);
    }

    public IResult Delete(Color color)
    {
        if(color == null && color.Id == null)
        {
            return new ErrorResult(Messages.ColorNameInvalid);
        }
        _colorDal.Delete(color);
        return new SuccessResult(Messages.ColorDeleted);
        
    }

    public IDataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListened); 
    }

    public IDataResult<Color> GetById(int colorId)
    {
        return new SuccessDataResult<Color>(_colorDal.Get(c=>c.Id == colorId),Messages.ColorListened);
    }

    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult(Messages.ColorUpdated);
    }
}
