using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCFlowerApp.Models;

namespace MVCFlowerApp.Controllers
{
    public class ProductsController : Controller
    {
        List<Tuple<tbl_products, int>> cart = new List<Tuple<tbl_products, int>>();
        private FlowerAppEntities db = new FlowerAppEntities();

        // GET: Products
        public ActionResult Index()
        {
            var tbl_products = db.tbl_products.Include(t => t.tbl_categories);
            return View(tbl_products.ToList());
        }
        

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_products tbl_products = db.tbl_products.Find(id);
            if (tbl_products == null)
            {
                return HttpNotFound();
            }
            return View(tbl_products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ID_Category = new SelectList(db.tbl_categories, "ID_category", "category");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code_product,Name,Price,Description,ID_Category,ID")] tbl_products tbl_products)
        {
            if (ModelState.IsValid)
            {
                db.tbl_products.Add(tbl_products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Category = new SelectList(db.tbl_categories, "ID_category", "category", tbl_products.ID_Category);
            return View(tbl_products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_products tbl_products = db.tbl_products.Find(id);
            if (tbl_products == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Category = new SelectList(db.tbl_categories, "ID_category", "category", tbl_products.ID_Category);
            return View(tbl_products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code_product,Name,Price,Description,ID_Category,ID")] tbl_products tbl_products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Category = new SelectList(db.tbl_categories, "ID_category", "category", tbl_products.ID_Category);
            return View(tbl_products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_products tbl_products = db.tbl_products.Find(id);
            if (tbl_products == null)
            {
                return HttpNotFound();
            }
            return View(tbl_products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_products tbl_products = db.tbl_products.Find(id);
            db.tbl_products.Remove(tbl_products);
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

        public ActionResult Customer(string username)
        {
            ViewBag.Message = username;
            return View();
        }

        public ActionResult ShowProducts(string category)
        {
            ViewBag.Message = category;
            var tbl_products = db.tbl_products.Include(t => t.tbl_categories);
            return View(tbl_products.ToList());

        }

        public void SumToCart(tbl_products tbl_product, int quantity)
        {
            Tuple<tbl_products, int> product_selected = new Tuple<tbl_products,int>(tbl_product, quantity);
            this.cart.Add(product_selected);
        }


    }
}
