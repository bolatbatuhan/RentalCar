using CorePackages.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework;

public class EfColorDal : EfEntityRepositoryBase<Color,KodlamaRentACarContext>, IColorDal
{
   
}
