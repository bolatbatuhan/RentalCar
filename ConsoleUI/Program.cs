
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarTest();
CarDetailTest();



static void CarTest()
{
    ICarDal carDal = new EfCarDal();
    CarManager carManager = new CarManager(carDal);

    var carToAdd = new Car
    {
        BrandId = 1,
        ColorId = 1,
        ModelYear = 2022,
        DailyPrice = 4500,
        Description = "BMW"

    };
    carManager.Add(carToAdd);
    Console.WriteLine($"{carToAdd.Id} {carToAdd.ModelYear} {carToAdd.Description} {carToAdd.DailyPrice} {carToAdd.ColorId}");

}



static void CarDetailTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine($"Araba adi : {car.CarName}, Marka adi : {car.BrandName}, Rengi {car.ColorName}, Gunlugu {car.DailyPrice}");
    }
}

