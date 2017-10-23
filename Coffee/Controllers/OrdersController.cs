using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coffee.DAL;
using Coffee.Models;

namespace Coffee.Controllers
{
    public class OrdersController : Controller
    {
        private CoffeeContext db = new CoffeeContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.User);
            return View(orders.ToList());
        }
        
        public ActionResult Place(List<Drink> B)
        {
            Amounts K;
           
            K = new Amounts (db.Drinks.ToList());
            
            return View(K);

        }
        public ActionResult Add(List<int> B)
        {
            List<Drink> menu = db.Drinks.ToList();
            List<Drink> A = new List<Drink>();
            foreach (int x in B)
            {
                for (int i = 0; i<x; i++)
                {
                    A.Add(menu[x]);
                }
            }
            Order ne = new Order();
            ne.Drinks = A;
            ne.Price = ne.Total();
            ne.Compl = false;
            ne.User = db.Users.Find(1);
            
            ne.UserID = 1;
            db.Users.Find(1).Orders.Add(ne);
            db.Orders.Add(ne);
            db.SaveChanges();

            return RedirectToAction("Menu", "Drinks", null);

        }
        public ActionResult ActiveOrders()
        {
            List<Order> ord = new List<Order>();
            var orders = db.Orders.ToList();
            foreach (Order x in orders)
            {
                if (x.Compl == false)
                {
                    ord.Add(x);
                }
            }
            return View(ord);
            
        }
        public ActionResult Finish (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            
            db.Orders.Find(id).Compl = true;
            db.SaveChanges();
            return RedirectToAction("ActiveOrders");
        }
        public ActionResult FinishedOrders()
        {
            List<Order> ord = new List<Order>();
            var orders = db.Orders.ToList();
            foreach (Order x in orders)
            {
                if (x.Compl == true)
                {
                    ord.Add(x);
                }
            }
            return View(ord);

        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            var drinks = db.Drinks.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            DrinkListStruct d = new DrinkListStruct(order, drinks);
            return View(d);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "Username");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Compl,Price,UserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "ID", "Username", order.UserID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "Username", order.UserID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Compl,Price,UserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "Username", order.UserID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
