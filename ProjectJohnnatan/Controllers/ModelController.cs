using ProjectJohnnatan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectJohnnatan.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                var allModels = dbModel.TModels.Include("TBrand").ToList();

                return View(allModels);
            }
        }

        // GET: Model/Details/id
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var chosenModel = dbModel.TModels.Include("TBrand").Where(x => x.ModelId == id).FirstOrDefault();

                return View(chosenModel);
            }
        }

        // GET: Model/Create
        [HttpGet]
        public ActionResult Create()
        {
            TModel theModel = new TModel();

            using (DbModels dbModel = new DbModels())
            {
                theModel.ListOfBrands = dbModel.TBrands.ToList<TBrand>();

                return View(theModel);
            }
        }

        // POST: Model/Create
        [HttpPost]
        public ActionResult Create(TModel theModel)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.TModels.Add(theModel);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index", "Model");
            }
            catch
            {
                return View();
            }
        }

        // GET: Model/Edit/id
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var theModel = dbModel.TModels.Include("TBrand").Where(x => x.ModelId == id).FirstOrDefault();
                theModel.ListOfBrands = dbModel.TBrands.ToList<TBrand>();
                
                return View(theModel);
            }
        }

        // POST: Model/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, TModel theModel)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(theModel).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index", "Model");
            }
            catch
            {
                return View();
            }
        }

        // GET: Model/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                var theModel = dbModel.TModels.Include("TBrand").Where(x => x.ModelId == id).FirstOrDefault();
                return View(theModel);
            }
        }

        // POST: Model/Delete/id
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    TModel theModel = dbModel.TModels.Include("TBrand").Where(x => x.ModelId == id).FirstOrDefault();
                    dbModel.TModels.Remove(theModel);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index", "Model");
            }
            catch
            {
                return View();
            }
        }


        // GET: Model/Search
        public ActionResult Search()
        {
            TModel theModel = new TModel();

            using (DbModels dbModel = new DbModels())
            {
                theModel.ListOfBrands = dbModel.TBrands.ToList<TBrand>();
                theModel.ListOfModels = dbModel.TModels.ToList<TModel>();

                return View(theModel);
            }
        }

        // GET: Model/Search
        [HttpPost]
        public ActionResult Search(TModel carModel)
        {

            using (DbModels dbModel = new DbModels())
            {
                var theSearchedCar = dbModel.TModels.Where(x => x.ModelId == carModel.ModelId).ToList();

                /*return RedirectToAction("SearchedCar", "Model" , theSearchedCar);*/
                return View("Search", "Model", theSearchedCar);
            }
        }

        public ActionResult SearchedCar()
        {
            return View();
        }
    }
}
