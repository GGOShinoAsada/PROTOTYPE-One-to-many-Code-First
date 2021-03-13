using DDD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.Controllers
{
    public class ProductsController : Controller
    {
        static FakeContext context = new FakeContext();
        // GET: Products
        public ActionResult Index()
        {
            var products = context.Products;
            foreach (Products p in products)
            {
                p.Position = context.Positions.Where(t => t.Id == p.PositionId).FirstOrDefault();
            }
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var c = context.Products.Where(t => t.Id == id).FirstOrDefault();
            if (c != null)
            {
                c.Position = (from data in context.Positions where data.Id == c.PositionId select data).FirstOrDefault();
                return View(c);
            }
            else
            {
                return HttpNotFound();
            }
           // var item = from 
            //return View(c);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            SelectList positions = new SelectList(context.Positions, "Id", "Name");
            
            ViewBag.Positions = positions;
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Products collection)
        {
           if (ModelState.IsValid)
           {
                context.Products.Add(collection);
                //context.SaveChanges();
                return RedirectToAction("Index");
           }
           else
           {
                return View();
           }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var item = context.Products.Where(t => t.Id == id).FirstOrDefault();
            item.Position = context.Positions.Where(t1 => t1.Id == item.PositionId).FirstOrDefault();
            SelectList positions = new SelectList(context.Positions, "Id", "Name", item.PositionId);
            //var item = context.ProductsContext.Where(t => t.Id == id).FirstOrDefault();
            return View(item);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products collection)
        {
            if (ModelState.IsValid)
            {

                var item = context.Products.Find(t=>t.Id==collection.Id);
                if (item != null)
                {
                    item.PositionId = collection.PositionId;
                    item.Rating = collection.Rating;
                    item.Name = collection.Name;
                    item.Description = collection.Description;
                    item.Position = context.Positions.Find(t => t.Id == item.PositionId);
                }
                else
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Products t = context.Products.Find(y => y.Id == id);
            context.Products.Remove(t);
            return RedirectToAction("Index");
        }
    }
}
