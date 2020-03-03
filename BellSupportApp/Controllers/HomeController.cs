using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BellSupportApp.DAL;
using BellSupportApp.ChartView;
using BellSupportApp.Models;

namespace BellSupportApp.Controllers
{
    public class HomeController : Controller
    {
        private BellDbContext db = new BellDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Charts()
        {
            //gets the number of tickets issued for each project
            IQueryable<Chart> data = from ticket in db.Tickets
                                     group ticket by ticket.ProjectName into projectGroup
                                     select new Chart()
                                     {
                                         ProjectName = projectGroup.Key,
                                         TicketCount = projectGroup.Count()
                                     };
        return View(data.ToList());
        } 
    }
}