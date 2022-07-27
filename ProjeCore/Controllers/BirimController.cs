using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class BirimController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var value = c.Birims.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddUnits()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUnits(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteUnits(int id)
        {
            var value = c.Birims.Find(id);
            c.Birims.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BringUnits(int id)
        {
            var values = c.Birims.Find(id);

            return View("BringUnits", values);

        }
        public IActionResult UpdateUnits(Birim d)
        {
            var values = c.Birims.Find(d.BirimID);
            values.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DetailUnits(int id)
        {
            var values = c.Personels.Where(x => x.BirimID == id).ToList();

            return View( values);

        }

    }
}
