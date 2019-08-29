using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcelHubWebTest.Models;

namespace ParcelHubWebTest.Controllers
{
    public class ProductController : Controller
    {
        //create db database instance of the class
        private ParcelHubDBEntities db = new ParcelHubDBEntities();
        // GET: Product
        public ActionResult Index()
        {
            //list all from Product table from the Database
            ViewBag.products = db.tblProducts.ToList();
            return View();
        }


        [HttpGet]
        // Get: Details
        public ActionResult Detail(int id)
        {   
            //find and entity with a given key and assign it to the object product created
            var product = db.tblProducts.Find(id);
            //for a selected id from the database find the product             
            ViewBag.product = product;
            //
            var review = new tblReview() { ProdId = product.ProdId };
            return View("Detail", review);
        }

        [HttpPost]
        public ActionResult SendReview(tblReview review/*, int rating*/)
        {
            string username = Session["username"].ToString();
            review.DatePost = DateTime.Now;
            review.AccId = db.tblAccounts.Single(a => a.Username.Equals(username)).AccId;
           // add the object review to the database
            db.tblReviews.Add(review);
            //save changes
            db.SaveChanges();
            //return to home page
            return RedirectToAction("Detail", "Product", new { id = review.ProdId });
        }
    }
}