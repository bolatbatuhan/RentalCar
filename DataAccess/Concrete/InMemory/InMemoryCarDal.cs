using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : ICarDal
{
    List<Car> _cars;
    public InMemoryCarDal()
    {
        _cars = new List<Car>()
        {
            new Car { Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 350, Description = "BMW", ModelYear = 2023 },
            new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 550, Description = "MERCEDES", ModelYear = 2023 },
            new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 499.9, Description = "AUDI", ModelYear = 2021 },
            new Car { Id = 4, BrandId = 2, ColorId = 2, DailyPrice = 1999, Description = "TOFAS", ModelYear = 2007 },
            new Car { Id = 5, BrandId = 2, ColorId = 1, DailyPrice = 3840, Description = "TOFAS", ModelYear = 2003 },
        };
    }
    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);

        _cars.Remove(carToDelete);
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public void GetById(Car car)
    {
        Car carToGet = _cars.SingleOrDefault(c=>c.Id==car.Id);
       
        
    }

    public List<CarDetailDto> GetCarDetails()
    {
        throw new NotImplementedException();
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(c=> c.Id==car.Id);
        carToUpdate.Id = car.Id;
        carToUpdate.BrandId = car.BrandId;
        carToUpdate.ColorId = car.ColorId;
        carToUpdate.DailyPrice = car.DailyPrice;
        carToUpdate.Description = car.Description;
        

    }
}
