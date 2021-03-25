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
        public FormDataContext db;
        //Using dependency injection to inject database into controller
        public FormController(FormDataContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Forms()
        {
            return View(db.Forms);
        }
        [HttpPost]
        public IActionResult Create(Form p)
        {
            //implement validating form here

            db.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
