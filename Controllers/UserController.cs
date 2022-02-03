using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCFlowerApp.Models;

namespace MVCFlowerApp.Controllers
{
    public class UserController : Controller
    {
        private FlowerAppEntities db = new FlowerAppEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.tbl_users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }

        // GET: User/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,name,lastname,password,address,mail,telephone,ID_user")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.tbl_users.Add(tbl_users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }

        public ActionResult MainMenu(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,name,lastname,password,address,mail,telephone,ID_user")] tbl_users tbl_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_users tbl_users = db.tbl_users.Find(id);
            if (tbl_users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_users);
        }


        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_users tbl_users = db.tbl_users.Find(id);
            db.tbl_users.Remove(tbl_users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (username == "aa" && password == "aa")
                {
                    return RedirectToAction("Index", "Products");
                }
                tbl_users user = db.tbl_users.FirstOrDefault(e => e.username == username);

                if (user != null)
                {
                    if (user.password == password)
                    {
                        FormsAuthentication.SetAuthCookie(user.username, true);
                        return RedirectToAction("Customer", "Products",new { username = user.username });
                    }
                    else
                    {
                        return RedirectToAction("MainMenu", "User", new { message = "The password was incorrect, please try again" });

                    }

                }
                else
                {
                    return RedirectToAction("MainMenu", "User", new { message = "The user does not exist, please try again" });
                }

                }
            else
                {
                    return RedirectToAction("MainMenu", "User", new { message = "Fill the username and password spaces" });
                } 
            
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
