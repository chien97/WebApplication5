using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class APPLICATIONsController : Controller
    {
        private StockEntities db = new StockEntities();

        // GET: APPLICATIONs
 
public ActionResult Index(string searchString)
{
    var deal = from m in db.APPLICATION
                 select m;
    if (!String.IsNullOrEmpty(searchString))
    {
        deal = deal.Where(s => s.StockID.Contains(searchString));
    }
    return View(deal);
}

// GET: APPLICATIONs/Details/5
public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLICATION aPPLICATION = db.APPLICATION.Find(id);
            if (aPPLICATION == null)
            {
                return HttpNotFound();
            }
            return View(aPPLICATION);
        }

        // GET: APPLICATIONs/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.OWNER, "OwnerID", "OwnerName");
            return View();
        }

        // POST: APPLICATIONs/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DealID,StockID,OwnerID,StockQuantity")] APPLICATION aPPLICATION)
        {
            if (ModelState.IsValid)
            {
                db.APPLICATION.Add(aPPLICATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.OWNER, "OwnerID", "OwnerName", aPPLICATION.OwnerID);
            return View(aPPLICATION);
        }

        // GET: APPLICATIONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLICATION aPPLICATION = db.APPLICATION.Find(id);
            if (aPPLICATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.OWNER, "OwnerID", "OwnerName", aPPLICATION.OwnerID);
            return View(aPPLICATION);
        }

        // POST: APPLICATIONs/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DealID,StockID,OwnerID,StockQuantity")] APPLICATION aPPLICATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPPLICATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.OWNER, "OwnerID", "OwnerName", aPPLICATION.OwnerID);
            return View(aPPLICATION);
        }

        // GET: APPLICATIONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLICATION aPPLICATION = db.APPLICATION.Find(id);
            if (aPPLICATION == null)
            {
                return HttpNotFound();
            }
            return View(aPPLICATION);
        }

        // POST: APPLICATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            APPLICATION aPPLICATION = db.APPLICATION.Find(id);
            db.APPLICATION.Remove(aPPLICATION);
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
