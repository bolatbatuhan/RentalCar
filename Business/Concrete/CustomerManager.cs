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

public class CustomerManager : ICustomerService
{
    ICustomersDal _customerDal;

    public CustomerManager(ICustomersDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IResult Add(Customers customers)
    {
        _customerDal.Add(customers);
        return new SuccessResult(Messages.CustomerAdded);
    }

    public IResult Delete(Customers customers)
    {
        _customerDal.Delete(customers);
        return new SuccessResult(Messages.CustomerDeleted);
    }

    public IDataResult<List<Customers>> GetAll()
    {
        return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), Messages.CustomerListed) ;
    }

    public IResult Update(Customers customers)
    {
        _customerDal.Update(customers);
        return new SuccessResult(Messages.CustomerUpdated);
    }
}
