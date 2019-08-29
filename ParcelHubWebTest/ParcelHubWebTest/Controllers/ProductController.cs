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
        {         //for a selected id from the database find the product             
            ViewBag.product = db.tblProducts.Find(id);
         
            return View("Detail");
        }
    }
}