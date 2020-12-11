using ProjectJohnnatan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectJohnnatan.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // POST: User/Create
        [HttpPost]
        public ActionResult Create(TUser user)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.TUsers.Add(user);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }


        // GET: User/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        // GET: User/Login
        [HttpPost]
        public ActionResult Login(TUser user)
        {
            using (DbModels dbModel = new DbModels())
            {
                var theUser = dbModel.TUsers.Where(x => x.UserEmail == user.UserEmail && x.UserPassword == user.UserPassword).FirstOrDefault();

                if (theUser == null)
                {
                    user.MessageLoginError = "Wrong username or password";
                    return View("Login" , user);
                }
                else
                {
                    Session["userId"] = theUser.UserId;
                    Session["userName"] = theUser.UserEmail;
                    return RedirectToAction("Sell");
                }
            }
        }


        // GET: User/Sell
        [HttpGet]
        public ActionResult Sell()
        {
            TUser theUser = new TUser();

            using (DbModels dbModel = new DbModels())
            {
                theUser.ListOfBrands = dbModel.TBrands.ToList<TBrand>();
                theUser.ListOfModels = dbModel.TModels.ToList<TModel>();

                return View(theUser);
            }
        }

        // GET: User/Sell
        [HttpPost]
        public ActionResult Sell(TUser user)
        {
            var price = Convert.ToInt32(user.Price);

            if(price == 0)
            {
                user.MessageLoginError = "Wrong username or password";
                return RedirectToAction("Sell", "User");
            }
            else
            {
                return RedirectToAction("Sell", "User");
            }
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }

    }
}