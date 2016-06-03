using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityCenterLibrary.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace CommunityCenterLibrary.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Clients/
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            //1. Using where method
            //var clientsByUserId = db.Clients.Where(c => c.ApplicationUser.Id == id);
            //return View(db.Clients.ToList());
            //2. LINQ
            IEnumerable<Client> clientsByUserId = from c in db.Clients
                                                   where c.ApplicationUser.Id == id
                                                   select c;

            return View(clientsByUserId.ToList());
        }

        // GET: /Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            var userId = User.Identity.GetUserId();
            if (client.ApplicationUser.Id != userId)
            {
                return RedirectToAction("Index");
            }
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: /Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Family,Age,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                client.ApplicationUser = db.Users.Find(id);
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: /Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            var userId = User.Identity.GetUserId();
            if (client.ApplicationUser.Id != userId)
            {
                return RedirectToAction("Index");
            }
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: /Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Family,Age,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: /Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            var userId = User.Identity.GetUserId();
            if (client.ApplicationUser.Id != userId)
            {
                return RedirectToAction("Index");
            }
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: /Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
