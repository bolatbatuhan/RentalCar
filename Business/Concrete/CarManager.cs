using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using CorePackages.Aspects.Autofac.Validation;
using CorePackages.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _cardal;

    public CarManager(ICarDal cardal)
    {
        _cardal = cardal;
    }
    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {

        _cardal.Add(car);
        return new SuccessResult(Messages.CarAdded);
    }

    public IResult Delete(Car car)
    {
        _cardal.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }

    public  IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.CarsListened);
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id)
    {

        return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.BrandId == id), Messages.BrandListened);
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id)
    {
        return new SuccessDataResult<List<Car>>(_cardal.GetAll(p=>p.ColorId == id), Messages.ColorListened);
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails(), Messages.CarDetailsListened);
    }

    [ValidationAspect(typeof(CarValidator))]
    public IResult Update(Car car)
    {
        _cardal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }
}
