using Microsoft.AspNetCore.Mvc;
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
            var value = c.Personels.ToList();
            return View(value);
        }
    }
}
