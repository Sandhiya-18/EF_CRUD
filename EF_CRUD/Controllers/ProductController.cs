﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF_CRUD.Context;
using EF_CRUD.Models;

namespace EF_CRUD.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)

        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id,Product prod)
        {
            try
            {
                Product product = new Product();
                if (ModelState.IsValid)
                {
                    db.products.Remove(product);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
