using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LekTest;

namespace LekTest.Controllers
{
    public class HomeController : Controller
    {
        private AccountDbContext db = new AccountDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.DailyPayments.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyPayment dailyPayment = db.DailyPayments.Find(id);
            if (dailyPayment == null)
            {
                return HttpNotFound();
            }
            return View(dailyPayment);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyPayment dailyPayment)
        {
            if (ModelState.IsValid)
            {
                db.DailyPayments.Add(dailyPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailyPayment);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyPayment dailyPayment = db.DailyPayments.Find(id);
            if (dailyPayment == null)
            {
                return HttpNotFound();
            }
            return View(dailyPayment);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Description,Amount,Date")] DailyPayment dailyPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailyPayment);
        }

        // GET: Home/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DailyPayment dailyPayment = db.DailyPayments.Find(id);
        //    if (dailyPayment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dailyPayment);
        //}

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            //SKGL.Generate CreateAKey = new SKGL.Generate(); // creating an object
            //CreateAKey.secretPhase = "My$ecretPa$$W0rd"; // adding password
            //string key = CreateAKey.doKey(30);

            //SKGL.Validate ValidateAKey = new SKGL.Validate();// create an object
            //ValidateAKey.secretPhase = "My$ecretPa$$W0rd"; // the passsword
            //ValidateAKey.Key = key; // enter a valid key

            DailyPayment dailyPayment = db.DailyPayments.Find(id);
            db.DailyPayments.Remove(dailyPayment);
            db.SaveChanges();
            //return RedirectToAction("Index");
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
