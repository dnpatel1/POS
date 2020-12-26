using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS.DAL;
using POS.Models;

namespace POS.Controllers
{
    public class UsersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["isAdmin"] != null)
            {

                return View(db.Users.ToList());

            }
            else
            {
                return RedirectToAction("Login", "Users");

            }
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {

            if (Session["isAdmin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Users");

            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Password,Name,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["isAdmin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Users");

            }
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Password,Name,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["isAdmin"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Users");

            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        /**************************************** for Registration ****************************/
        //Route: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index", "Home");

        }

        /****************************************For Login**************************/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
            try
            {
                var usr = db.Users.Single(u => u.Email == user.Email && u.Password == user.Password);
                if (usr != null)
                {
                    Session["useremail"] = usr.Email.ToString();
                    Session["username"] = usr.Name.ToString();

                    //Based on the user role redirect the user to admin or employee views

                    if (usr.IsAdmin)
                    {

                        //If user is admin, take the user to the admin index page
                        Session["isAdmin"] = "ADMIN";
                        return RedirectToAction("Index", "Admin");

                    }
                    else {
                        //If user is not an admin, take the user to the employee index page
                        //Cart.UserName = Session["username"].ToString();
                        Session["user"] = "Emplyee";
                        Cart.UserName = user.Name;
                        return RedirectToAction("LoggedIn");

                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View();
        }

           /***************For Employee******************/
        public ActionResult LoggedIn()
        {
            if (Session["useremail"] != null)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                Cart.temp_cart_id = 0; 
                Cart.temp_cart_id= rand.Next(1, 10000);
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        /********Logout********/
        public ActionResult Logout()
        {
            Session.Remove("useremail");
            Session.Remove("username");
            if (Session["isAdmin"] != null) {
                Session.Remove("isAdmin");
            }
            else
            {
                Session.Remove("user");
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
