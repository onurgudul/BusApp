using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.ViewModels;
using TepeBusApp.Web.Filters;

namespace TepeBusApp.Web.Areas.Admin.Controllers
{
    [AuthAdmin]
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITravelService _travelService;
        private readonly ISeatService _seatService;
        private readonly IUserService _userService;
        public TicketsController(ITicketService ticketService, ITravelService travelService, ISeatService seatService, IUserService userService)
        {
            _ticketService = ticketService;
            _travelService = travelService;
            _seatService = seatService;
            _userService = userService;

        }
        // GET: Admin/Ticket
        public ActionResult Index()
        {
            var res = _ticketService.GetList().Data.Where(x => x.isDeleted == false);
            var res2 = _userService.GetList().Data;
            var res3 = _seatService.GetList().Data.Where(x => x.isDeleted == false).ToList();
            var res4 = _travelService.GetList().Data;
            TicketViewModel tvm = new TicketViewModel()
            {
                Seats = res3,
                Users = res2,
                Tickets = res,
                Travels = res4

            };
            return View(tvm);
        }




        public ActionResult Delete(int id)
        {
            var ticket = _ticketService.GetById(id).Data;
            ticket.isDeleted = true;
            var seat = _seatService.GetList().Data.Where(x => x.Seats == ticket.SeatId.ToString()).FirstOrDefault();
            seat.isDeleted = true;

            _ticketService.Update(ticket);
            _seatService.Update(seat);
            return RedirectToAction("Index", "Tickets");

        }

    }
}