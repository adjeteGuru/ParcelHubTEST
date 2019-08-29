using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcelHubWebTest.Models;

namespace ParcelHubWebTest.Controllers
{
    public class AccountController : Controller
    {
        //
        private ParcelHubDBEntities db = new ParcelHubDBEntities();
        
        //to handle only get request
        [HttpGet]
        // GET: Account
        public ActionResult Login()
        {
            return View("Login");
        }

        //to handle only post request
        [HttpPost]

        //public ActionResult Login(tblAccount account)
        public ActionResult Login(string username, string password)
        {
            //create count object and assign counted user acount data from database
            var count = db.tblAccounts.Count(a => a.Username.Equals(username) && a.Password.Equals(password));

            // if there is a data (user logged In details)
            if (count > 0)
            {
                //store the logged In User detail into username session
                Session["username"] = username;

                //then go back to index page
                return RedirectToAction("Index", "Product");
            }
            else
            {
                //display message
                ViewBag.error = "Invalid Account";

                //load login page
                return View("Login");
            }

           
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]

        public ActionResult SignUp(tblAccount account)
        {
            //this to add new account details to the account table
            db.tblAccounts.Add(account);

            //this to save account details changes
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }
    }
}