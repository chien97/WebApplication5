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
    public class OWNERsController : Controller
    {
        private StockEntities db = new StockEntities();

        // GET: OWNERs
        public ActionResult Index(string sString)
        {
            var deal = from m in db.OWNER
                       select m;
            if (!String.IsNullOrEmpty(sString))
            {
                deal = deal.Where(s => s.OwnerID.Contains(sString));
            }
            return View(deal);
        }
        // GET: OWNERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OWNER oWNER = db.OWNER.Find(id);
            if (oWNER == null)
            {
                return HttpNotFound();
            }
            return View(oWNER);
        }

        // GET: OWNERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OWNERs/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerID,OwnerName")] OWNER oWNER)
        {
            if (ModelState.IsValid)
            {
                db.OWNER.Add(oWNER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oWNER);
        }

        // GET: OWNERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OWNER oWNER = db.OWNER.Find(id);
            if (oWNER == null)
            {
                return HttpNotFound();
            }
            return View(oWNER);
        }

        // POST: OWNERs/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerID,OwnerName")] OWNER oWNER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oWNER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oWNER);
        }

        // GET: OWNERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OWNER oWNER = db.OWNER.Find(id);
            if (oWNER == null)
            {
                return HttpNotFound();
            }
            return View(oWNER);
        }

        // POST: OWNERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OWNER oWNER = db.OWNER.Find(id);
            db.OWNER.Remove(oWNER);
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
