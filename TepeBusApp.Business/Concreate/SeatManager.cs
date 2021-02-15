using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Data.Abstract;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.Dto;

namespace TepeBusApp.Business.Concreate
{
    public class SeatManager : ISeatService
    {
        private readonly ISeatDal _seatDal;
        public SeatManager(ISeatDal seatDal)
        {
            _seatDal = seatDal;
        }
        public IResult Add(Seat entity)
        {
            _seatDal.Create(entity);
            return new SuccessResult();
        }

        public IDataResult<Seat> Added(SeatDto seatDto)
        {
            var seat = new Seat()
            {
                Seats = seatDto.Seat,
                TravelId = seatDto.TravelId
            };
            _seatDal.Create(seat);
            return new SuccessDataResult<Seat>();

        }

        public IResult Delete(Seat entity)
        {
            _seatDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Seat> GetById(int id)
        {
            return new SuccessDataResult<Seat>(_seatDal.Get(x => x.Id == id));
        }

        public IDataResult<List<Seat>> GetList()
        {
            return new SuccessDataResult<List<Seat>>(_seatDal.GetAll());
        }

        public IDataResult<List<Seat>> GetSeat(int? id)
        {
            return new SuccessDataResult<List<Seat>>(_seatDal.GetSeat(id));
        }

        public IResult Update(Seat entity)
        {
            _seatDal.Update(entity);
            return new SuccessResult();

        }
    }
}
