using ProjectJohnnatan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectJohnnatan.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administrator/Details/id
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Create
        [HttpPost]
        public ActionResult Create(TAdministrator administrator)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.TAdministrators.Add(administrator);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Login" , "Administrator");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Administrator/Login
        [HttpPost]
        public ActionResult Login(TAdministrator administrator)
        {
            using (DbModels dbModel = new DbModels())
            {
                var theAdministrator = dbModel.TAdministrators.Where(x => x.AdministratorUser == administrator.AdministratorUser && x.AdministratorPassword == administrator.AdministratorPassword).FirstOrDefault();

                if (theAdministrator == null)
                {
                    administrator.MessageLoginError = "Wrong username or password";
                    return View("Login", administrator);
                }
                else
                {
                    Session["administratorId"] = theAdministrator.AdministratorId;
                    Session["administratorUser"] = theAdministrator.AdministratorUser;
                    return RedirectToAction("DashBoard" , "Administrator");
                }
            }
        }

        // GET: Administrator/Dashboard
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login" , "Administrator");
        }
    }
}
