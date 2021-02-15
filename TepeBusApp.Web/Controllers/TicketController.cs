using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.Dto;
using TepeBusApp.Entities.ViewModels;
using TepeBusApp.Web.Filters;
using TepeBusApp.Web.Models;

namespace TepeBusApp.Web.Controllers
{
    [Auth]
    public class TicketController : Controller
    {
        private readonly ITravelService _travelService;
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;
        private readonly ISeatService _seatService;
        public TicketController(ITravelService travelService, IUserService userService, ITicketService ticketService, ISeatService seatService)
        {
            _travelService = travelService;
            _userService = userService;
            _ticketService = ticketService;
            _seatService = seatService;
        }
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TravelChoose()
        {
            var model = _travelService.GetList().Data;
            return View(model);
        }
        public ActionResult ShowSeat(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var res = _travelService.GetList().Data;
            var res2 = _userService.GetList().Data;
            var res3 = _seatService.GetList().Data.Where(x => x.TravelId == id).Where(x => x.isDeleted == false).ToList();

            var ticketVm = new TicketViewModel
            {
                Travels = res.Where(x => x.Id == id).ToList(),
                Users = res2.Where(x => x.Id == SessionManager.User.Id),
                Seats = res3
            };
            return PartialView("_PartialSeat", ticketVm);
        }

        [HttpPost]
        public ActionResult Take(int Property1, int Property2)
        {
            var travel = _travelService.GetById(Property2).Data;
            var travels = _seatService.GetList().Data.Where(x => x.TravelId == Property2 && x.isDeleted == false).Count();



            if (travels != 0 && travels % 5 == 0)
            {
                travel.StartPrice += Convert.ToInt32(travel.StartPrice * 0.10);
                _travelService.Update(travel);
            }

            //switch (travels)
            //{
            //    case 5:
            //        travel.StartPrice += travel.StartPrice * 0.10;
            //        _travelService.Update(travel);
            //        break;
            //    case 10:
            //        travel.StartPrice += travel.StartPrice * 0.10;
            //        _travelService.Update(travel);
            //        break;
            //    case 15:
            //        travel.StartPrice += travel.StartPrice * 0.10;
            //        _travelService.Update(travel);
            //        break;
            //    default:
            //        break;
            //}

            Seat seat = new Seat()
            {
                TravelId = Property2,
                Seats = Property1.ToString(),
                isDeleted = false
            };
            Ticket ticket = new Ticket()
            {
                UserId = SessionManager.User.Id,
                TravelId = Property2,
                SeatId = Property1,
                isDeleted = false,
                Price = travel.StartPrice
            };
            _ticketService.Add(ticket);
            if (_seatService.Add(seat).Success)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }


    }
}