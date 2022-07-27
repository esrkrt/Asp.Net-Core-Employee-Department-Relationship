using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var value = c.Personels.Include(x => x.Birim).ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<SelectListItem> values = (from x in c.Birims.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BirimAd,
                                               Value = x.BirimID.ToString()
                                           }).ToList();
            ViewBag.dgr = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Personel b)
        {
            var per = c.Birims.Where(x => x.BirimID == b.Birim.BirimID).FirstOrDefault();
            b.Birim = per;
            c.Personels.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteEmployee(int id)
        {
            var value = c.Personels.Find(id);
            c.Personels.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
