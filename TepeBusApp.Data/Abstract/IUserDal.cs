using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Abstract;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Data.Abstract
{
    public interface IUserDal : IRepository<User>
    {

    }
}
