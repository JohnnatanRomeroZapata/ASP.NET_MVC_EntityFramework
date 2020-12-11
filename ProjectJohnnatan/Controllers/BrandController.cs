using ProjectJohnnatan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectJohnnatan.Controllers
{
    public class BrandController : Controller
    {
            // GET: Brand
            public ActionResult Index()
            {
                using (DbModels dbModel = new DbModels())
                {
                    var allBrands = dbModel.TBrands.ToList();
                    return View(allBrands);
                }
            }

            // GET: Brand/Details/id
            public ActionResult Details(int id)
            {
                using (DbModels dbModel = new DbModels())
                {
                    var chosenBrand = dbModel.TBrands.Where(x => x.BrandId == id).FirstOrDefault();
                    return View(chosenBrand);
                }
            }

            // GET: Brand/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Brand/Create
            [HttpPost]
            public ActionResult Create(TBrand brand)
            {
                try
                {
                    using (DbModels dbModel = new DbModels())
                    {
                        dbModel.TBrands.Add(brand);
                        dbModel.SaveChanges();
                    }

                    return RedirectToAction("Index" , "Brand");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Brand/Edit/id
            public ActionResult Edit(int id)
            {
                using (DbModels dbModel = new DbModels())
                {
                    var theBrand = dbModel.TBrands.Where(x => x.BrandId == id).FirstOrDefault();
                    return View(theBrand);
                }
            }
            
            // POST: Brand/Edit/id
            [HttpPost]
            public ActionResult Edit(int id, TBrand brand)
            {
                try
                {
                    using (DbModels dbModel = new DbModels())
                    {
                        dbModel.Entry(brand).State = EntityState.Modified;
                        dbModel.SaveChanges();
                    }

                    return RedirectToAction("Index" , "Brand");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Brand/Delete/id
            public ActionResult Delete(int id)
            {
                using (DbModels dbModel = new DbModels())
                {
                    var theBrand = dbModel.TBrands.Where(x => x.BrandId == id).FirstOrDefault();
                    return View(theBrand);
                }
            }

            // POST: Brand/Delete/id
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    using (DbModels dbModel = new DbModels())
                    {
                        TBrand brand = dbModel.TBrands.Where(x => x.BrandId == id).FirstOrDefault();
                        dbModel.TBrands.Remove(brand);
                        dbModel.SaveChanges();
                    }

                    return RedirectToAction("Index" , "Brand");
                }
                catch
                {
                    return View();
                }
            }
    }
}
