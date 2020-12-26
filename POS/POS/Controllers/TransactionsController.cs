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
    public class TransactionsController : Controller
    {
        private DataContext db = new DataContext();
        Product prod_obj;
        private List<Product> temp_prod; // To add all products in a one particular transaction


        // GET: Transactions
        public ActionResult Index()
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
                return View(db.Transactions.ToList());
        }

        //Change the transaction table to refer to TransProd to get the details of the Transaction
        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transaction transaction = db.Transactions.Find(id);
                if (transaction == null)
                {
                    return HttpNotFound();
                }
                return View(transaction);
            }
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
                return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount_Total,Method_Of_Payment")] Transaction transaction)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(transaction);
            }
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transaction transaction = db.Transactions.Find(id);
                if (transaction == null)
                {
                    return HttpNotFound();
                }
                return View(transaction);
            }
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount_Total,Method_Of_Payment")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transaction transaction = db.Transactions.Find(id);
                if (transaction == null)
                {
                    return HttpNotFound();
                }
                return View(transaction);
            }
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                Transaction transaction = db.Transactions.Find(id);
                db.Transactions.Remove(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
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

        /**********For Employee*********/

        /********After Login Screen List Of Products**********/

        public ActionResult AllProduct()
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
                return View(db.Products.ToList());
        }

        /************Add to Cart**********/

        // GET: Transactions/Add/5
        public ActionResult AddProductToCart(int id)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                prod_obj = new Product();
                prod_obj = db.Products.Find(id);
                if (prod_obj == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Cart.Products.Add(prod_obj);
                    return RedirectToAction("AllProduct");
                }
            }

        }

        /*******************************Cart****************/
        public ActionResult Cart1()
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
                return View();
        }
        /*******************************Remove Product from Cart*************************/

        // GET: Transaction/RemoveProduct/5
        public ActionResult RemoveProduct(int id)
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                prod_obj = new Product();
                //prod_obj = db.products.Find(id);
                prod_obj = Cart.Products.Find(x => x.Id == id);
                Cart.Products.Remove(prod_obj);
                // return View();
                return RedirectToAction("Cart1");
            }

        }

        /************************Check out *************************/

        public ActionResult CheckOut() 
        {
            if (Session["useremail"] == (null))
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                double total = 00;
                foreach (var prd in Cart.Products)
                {
                    //Total of all products
                    total += prd.product_price;
                    //Reduce Quantity in product table
                    var result = db.Products.SingleOrDefault(b => b.Id == prd.Id);
                    if (result != null)
                    {
                        result.stock_remaining = prd.stock_remaining - 1;
                        db.SaveChanges();
                    }
                }

                //Add transaction to database- Transaction table
                Transaction tempadd = new Transaction 
                {
                    products = temp_prod,
                    Amount_Total = total,
                    Method_Of_Payment = 1,  //get detail
                    Date = DateTime.Now,
                    cart_id = Cart.temp_cart_id
                };

                db.Transactions.Add(tempadd);
                db.SaveChanges();
                //Get transaction-id from database because it is set as auto increment.
                var tran_obj = db.Transactions.SingleOrDefault(t => t.cart_id == Cart.temp_cart_id);
                int tran_id = tran_obj.Id;
                //Add each product from current transaction to tran-prod table for admin analysis.
                TransProd transProd;
                //Get Quantity of single product
                //dictionary<productId,Quantity>
                Dictionary<int, int> qnty = new Dictionary<int, int>();
                foreach (var prd in Cart.Products)
                {
                    //Increase quantity if product is already in Dictionary 
                    if (qnty.ContainsKey(prd.Id)) 
                    {
                        int temp = qnty[prd.Id];
                        qnty.Remove(prd.Id);
                        temp++;
                        qnty.Add(prd.Id, temp);
                    }
                    else
                    {
                        qnty.Add(prd.Id, 1);
                    }
                }
                //Add data to tran-prod table for one to many relaionship
                List<int> temp1 = new List<int>(Cart.Products.Count());
                temp1.Add(-8);
                foreach (var prd in Cart.Products)
                {
                    if (temp1.Contains(prd.Id))
                    {

                    }
                    else
                    {
                        temp1.Add(prd.Id);
                        transProd = new TransProd();
                        transProd.ProductId = prd.Id;
                        transProd.ProductQuantity = qnty[prd.Id];
                        transProd.TransactionId = tran_id;
                        db.TransProds.Add(transProd);
                        db.SaveChanges();
                    }
                }
                
                Cart.Products.Clear(); //Clear Cart at the end of transaction
                Cart.temp_cart_id = 0;  //Set Card id =0
                Cart.UserName = "";//Clear Username
                
                return RedirectToAction("Index","TransProds", new { id = tran_id });
               
            }
        }

    }
}
