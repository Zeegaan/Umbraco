using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmbracoProjekt.Models;

namespace UmbracoProjekt.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person p)
        {
            return View();
        }
    }
}
