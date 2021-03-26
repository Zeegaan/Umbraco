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
        public SerialNumberRepo numberRepo;
        //Using dependency injection to inject database into controller
        public FormController(FormDataContext db, SerialNumberRepo numberRepo)
        {
            this.db = db;
            this.numberRepo = numberRepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(db.Forms);
        }
        [HttpPost]
        public IActionResult Create(Form p)
        {
            //Checking if form model is valid
            if (!ModelState.IsValid)
            {
                return View();
            }
            //checking if serialnumber is a number in the draw & then sending error to user if it isn't
            if (!CheckIfValid(p.SerialNumber))
            {
                ModelState.AddModelError("", "Serialnumber is not valid");
                return View();
            }
            //Checking if serialnumber is already used twice and sending error to user if its used
            if (!CheckIfUsedTwice(p.SerialNumber))
            {
                ModelState.AddModelError("", "Serialnumber already used twice");
                return View();
            }

            db.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public bool CheckIfValid(string serialNumber)
        {
            foreach (var number in numberRepo.Get())
            {
                if(number == serialNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckIfUsedTwice(string serialNumber)
        {
            List<string> usedNumbers = new List<string>();
            foreach (var form in db.Forms)
            {
                if(form.SerialNumber == serialNumber)
                {
                    usedNumbers.Add(form.SerialNumber);
                }
                if(usedNumbers.Count == 2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
