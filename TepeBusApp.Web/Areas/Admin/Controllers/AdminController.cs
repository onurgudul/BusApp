using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Web.Filters;

namespace TepeBusApp.Web.Areas.Admin.Controllers
{
    [AuthAdmin]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            var user = _userService.GetList().Data;
            return View(user);
        }
        
    }
}