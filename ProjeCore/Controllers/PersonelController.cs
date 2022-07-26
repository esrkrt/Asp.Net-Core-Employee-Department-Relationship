﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult BringEmployee(int id)
        {
            List<SelectListItem> values = (from x in c.Birims.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.BirimAd,
                                             Value = x.BirimID.ToString()
                                         }).ToList();
            ViewBag.dgr = values;

            var per = c.Personels.Find(id);
            return View("BringEmployee", per);

        }
        public IActionResult UpdateEmployee(Personel p)
        {
            var values = c.Personels.Find(p.PersonelID);
            values.PersonelAd = p.PersonelAd;
            values.PersonelAd = p.PersonelAd;
            values.PersonelSoyad = p.PersonelSoyad;
            values.PersonelSehir = p.PersonelSehir;
            values.BirimID = p.BirimID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
