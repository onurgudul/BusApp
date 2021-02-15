using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Entities.DatabaseTable;
using TepeBusApp.Web.Filters;

namespace TepeBusApp.Web.Areas.Admin.Controllers
{
    [AuthAdmin]
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }
        // GET: Admin/Travel
        public ActionResult Index()
        {
            var travelList = _travelService.GetList().Data;
            return View(travelList);
        }

        // GET: Admin/Travel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Travel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Travel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Travel travel)
        {
            _travelService.Add(travel);
            return RedirectToAction("Index");
        }

        // GET: Admin/Travel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Travel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Travel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Travel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
