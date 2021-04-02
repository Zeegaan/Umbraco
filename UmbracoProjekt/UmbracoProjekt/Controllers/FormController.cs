using Microsoft.AspNetCore.Authorization;
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
        private FormDataContext db;
        private SerialNumberRepo numberRepo;
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
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var forms = db.Forms.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.LastName.Contains(searchString)
                                       || f.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    forms = forms.OrderByDescending(f => f.Id);
                    break;
                case "name_desc":
                    forms = forms.OrderByDescending(f => f.FirstName);
                    break;
                case "Name":
                    forms = forms.OrderBy(f => f.FirstName);
                    break;
                default:
                    forms = forms.OrderBy(f => f.Id);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Form>.CreateAsync(forms, pageNumber ?? 1, pageSize));

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

            db.Forms.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Numbers()
        {
            return View(numberRepo.Get());
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
            if(db.Forms.EntityType == null)
            {
                return true;
            }
            List<string> usedNumbers = new List<string>();
            foreach (var form in db.Forms)
            {
                if (form.SerialNumber == serialNumber)
                {
                    usedNumbers.Add(form.SerialNumber);
                }
                if (usedNumbers.Count == 2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
