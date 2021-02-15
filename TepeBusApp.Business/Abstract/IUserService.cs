using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByMail(string mail);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetList();
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
    }
}
