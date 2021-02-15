using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Data.Abstract;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Business.Concreate
{
    public class TravelManager : ITravelService
    {
        private readonly ITravelDal _travelDal;
        public TravelManager(ITravelDal travelDal)
        {
            _travelDal = travelDal;
        }
        public IResult Add(Travel entity)
        {
            _travelDal.Create(entity);
            return new SuccessResult();
        }

        public IResult Delete(Travel entity)
        {
            _travelDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Travel> GetById(int userId)
        {
            return new SuccessDataResult<Travel>(_travelDal.Get(filter: u => u.Id == userId));
        }


        public IDataResult<List<Travel>> GetList()
        {
            return new SuccessDataResult<List<Travel>>(_travelDal.GetAll());
        }
        public IDataResult<List<Travel>> TravelWithSeat(int? id)
        {
            return new SuccessDataResult<List<Travel>>(_travelDal.TravelWithSeat().Where(t => t.Id == id).ToList());
        }

        public IResult Update(Travel entity)
        {
            _travelDal.Update(entity);
            return new SuccessResult();
        }
    }
}
