using POS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class AdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["isAdmin"] != null)
            {

                var transactions = db.Transactions.OrderBy(t => t.Date).ToList();

                return View(transactions);

            }
            else if(Session["user"].Equals("Employee")) {

                return RedirectToAction("Login", "Users");

            }
            else
            {
                return RedirectToAction("Login", "Users");
            }

            
        }
        
        public ActionResult Payments()
        {
            if (Session["isAdmin"] != null)
            {

                var transactions = db.Transactions.ToList();

                return View(transactions);

            }
            else
            {

                return RedirectToAction("Login", "Users");

            }

        }
        
    }
}