using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BellSupportApp.DAL;
using BellSupportApp.Models;


namespace BellSupportApp.Controllers
{
    public class TicketController : Controller
    {
        private BellDbContext db = new BellDbContext();


        // GET: Ticket
        public ActionResult Index(string sortTicket, string searchTicket)
        {
            //sort ticket based of user selection
            ViewBag.ProjSort = sortTicket == "Project" ? "Project-Desc" : "Project";
            ViewBag.DepSort = sortTicket == "Department" ? "Department-Desc" : "Department";
            ViewBag.DescSort = sortTicket == "Description" ? "Description-Desc" : "Description";
            ViewBag.ReqSort = sortTicket == "Requestor" ? "Requestor-Desc" : "Requestor";
            ViewBag.DateSort = sortTicket == "Date" ? "Date-Desc" : "Date";

            //search ticket from search field
            var tickets = from t in db.Tickets
                          select t;
            if (!string.IsNullOrEmpty(searchTicket))
            {
                tickets = tickets.Where(t => t.ProjectName.Contains(searchTicket)
                                        || t.DepartmentName.Contains(searchTicket)
                                        || t.Requestor.Contains(searchTicket)
                                        || t.Description.Contains(searchTicket));
            }
            //this will sort the tickets based of the sortTicket selection received
            switch (sortTicket)
            {
                case "Project":
                    tickets = tickets.OrderBy(t => t.ProjectName);
                    break;

                case "Project-Desc":
                    tickets = tickets.OrderByDescending(t => t.ProjectName);
                    break;

                case "Department":
                    tickets = tickets.OrderBy(t => t.DepartmentName);
                    break;

                case "Department-Desc":
                    tickets = tickets.OrderByDescending(t => t.DepartmentName);
                    break;

                case "Description":
                    tickets = tickets.OrderBy(t => t.Description);
                    break;

                case "Description-Desc":
                    tickets = tickets.OrderByDescending(t => t.Description);
                    break;

                case "Requestor":
                    tickets = tickets.OrderBy(t => t.Requestor);
                    break;

                case "Requestor-Desc":
                    tickets = tickets.OrderByDescending(t => t.Requestor);
                    break;

                case "Date":
                    tickets = tickets.OrderBy(t => t.RequestDate);
                    break;

                default:
                    tickets = tickets.OrderByDescending(t => t.RequestDate);
                    break;
            }
            return View(tickets.ToList());
        }


        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            //populating the drop down list with department and employee data
            using (BellDbContext dbContext = new BellDbContext())
            {
                var deptList = new SelectList(dbContext.Departments.OrderBy(t => t.DepartmentName).ToList(), "DepartmentName", "DepartmentName");
                ViewData["DbDepartment"] = deptList;

                var name = new SelectList(dbContext.Employees.OrderBy(t => t.Name).ToList(), "Name", "Name");
                ViewData["DbEmployee"] = name;

            }
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectName,DepartmentName,Description,Requestor")] Ticket ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ticket.RequestDate = DateTime.Now;
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException )
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectName,Description")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
