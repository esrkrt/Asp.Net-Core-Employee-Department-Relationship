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
    }
}
