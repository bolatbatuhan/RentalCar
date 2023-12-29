using Business.Abstract;
using Business.Constans;
using CorePackages.Utilities.Business;
using CorePackages.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    IRentalsDal _rentalsdal;

    public RentalManager(IRentalsDal rentalsdal)
    {
        _rentalsdal = rentalsdal;
    }

    public IResult Add(Rentals rentals)
    {
        IResult result = BusinessRules.Run
            (CheckRentalReturnDate(rentals.ReturnDate)

            );
        if(result !=null )
        {
            return result;
        }
        _rentalsdal.Add(rentals);
        return new SuccessResult(Messages.RentalSuccess);
    }

    public IResult Delete(Rentals rentals)
    {
        _rentalsdal?.Delete(rentals);
        return new SuccessResult(Messages.RentalDeleted);
    }

    public IDataResult<List<Rentals>> GetAll()
    {
        return new SuccessDataResult<List<Rentals>>(_rentalsdal.GetAll(),Messages.RentalListed);
    }

    public IResult Update(Rentals rentals)
    {
        _rentalsdal.Update(rentals);
        return new SuccessResult();
    }

    private IResult CheckRentalReturnDate(DateTime? returnDate)
    {
        var result = _rentalsdal.GetAll(c=>c.ReturnDate == returnDate);
        if(result.Any())
        {
            return new ErrorResult(Messages.RentalDidntReturn);
        }
        return new SuccessResult();
    }
}
