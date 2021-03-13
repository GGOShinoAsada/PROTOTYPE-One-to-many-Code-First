using DDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DDD.Controllers
{
    public class PositionsController : Controller
    {
        static FakeContext context = new FakeContext();
      
        // GET: Positions
        public ActionResult Index()
        {
            
            var items = from c in context.Positions select c;

            return View(items);
     
        }

        // GET: Positions/Details/5
        public ActionResult Details(int id)
        {
            var item = (from c in context.Positions where c.Id == id select c).FirstOrDefault();
            return View(item);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        public ActionResult Create(Positions collection)
        {

                if (ModelState.IsValid)
                {
                    context.Positions.Add(collection);
                   
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            
           
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int id)
        {
            var item = context.Positions.Where(t => t.Id == id).FirstOrDefault();
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Positions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Positions pos)
        {
            if (ModelState.IsValid)
            {
                var item = context.Positions.Where(t => t.Id == id).FirstOrDefault();
                if (item != null)
                {
                    item.Name = pos.Name;
                    item.Description = pos.Description;
                    item.Character = pos.Character;
                  
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","некоррекные данные");
                    return View();
                }               
            }
            else
            {
                return View();
            }
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int id)
        {
            var item = context.Positions.Where(t => t.Id == id).FirstOrDefault();
            context.Positions.Remove(item);
            return RedirectToAction("Index");
        }

       
      
    }
}
