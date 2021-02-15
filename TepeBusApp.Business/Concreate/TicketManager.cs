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
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }
        public IResult Add(Ticket entity)
        {
            _ticketDal.Create(entity);
            return new SuccessResult();
        }

        public IResult Delete(Ticket entity)
        {
            _ticketDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Ticket> GetById(int userId)
        {
            return new SuccessDataResult<Ticket>(_ticketDal.Get(filter: u => u.Id == userId));
        }


        public IDataResult<List<Ticket>> GetList()
        {
            return new SuccessDataResult<List<Ticket>>(_ticketDal.GetAll());
        }
        public IResult Update(Ticket entity)
        {
            _ticketDal.Update(entity);
            return new SuccessResult();
        }
    }
}
