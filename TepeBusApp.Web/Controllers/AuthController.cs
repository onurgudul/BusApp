using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Entities.Dto;
using TepeBusApp.Web.Models;

namespace TepeBusApp.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO loginDTO)
        {
            var userLogin = _authService.Login(loginDTO);
            if (!userLogin.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionManager.Set<User>("login", userLogin.Data);
            if (SessionManager.User.isAdmin)
            {
                return RedirectToAction("Admin/Index","Admin");
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterDTO registerDTO)
        {
            var userRePassword = _authService.RePassword(registerDTO);
            if (userRePassword == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var userExist = _authService.UserExist(registerDTO.Email);
            if (!userExist.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var RegisterResult = _authService.Register(registerDTO, registerDTO.Password);
            if (!RegisterResult.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}