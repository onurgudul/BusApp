using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.Dto;

namespace TepeBusApp.Business.Abstract
{
    public interface ISeatService
    {
        IDataResult<Seat> Added(SeatDto seatDto);
        IDataResult<List<Seat>> GetSeat(int? id);
        IDataResult<Seat> GetById(int id);
        IDataResult<List<Seat>> GetList();
        IResult Add(Seat entity);
        IResult Update(Seat entity);
        IResult Delete(Seat entity);
    }
}
