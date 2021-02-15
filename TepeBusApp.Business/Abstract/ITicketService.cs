using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Business.Abstract
{
    public interface ITicketService
    {
        
        IDataResult<Ticket> GetById(int id);
        IDataResult<List<Ticket>> GetList();
        IResult Add(Ticket entity);
        IResult Update(Ticket entity);
        IResult Delete(Ticket entity);
    }
}
