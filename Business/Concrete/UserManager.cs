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

public class UserManager : IUserService
{
    IUsersDal _userdal;

    public UserManager(IUsersDal userdal)
    {
        _userdal = userdal;
    }

    public IResult Add(Users users)
    {
        _userdal.Add(users);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(Users users)
    {
        _userdal.Delete(users);
        return new SuccessResult(Messages.UserDeleted);
    }

    public IDataResult<List<Users>> GetAll()
    {
        return new SuccessDataResult<List<Users>>(_userdal.GetAll(),Messages.UserListed);
    }

    public IResult Update(Users users)
    {
        _userdal.Update(users);
        return new SuccessResult(Messages.UserUpdated);
    }
}
