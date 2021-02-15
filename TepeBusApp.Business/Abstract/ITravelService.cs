using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Business.Abstract
{
    public interface ITravelService
    {
        IDataResult<List<Travel>> TravelWithSeat(int? id);
        IDataResult<Travel> GetById(int userId);
        IDataResult<List<Travel>> GetList();
        IResult Add(Travel entity);
        IResult Update(Travel entity);
        IResult Delete(Travel entity);
    }
}
