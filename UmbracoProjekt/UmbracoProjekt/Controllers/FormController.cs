using Draw;
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
        DrawRules rules;
        //Using dependency injection to inject database into controller
        public FormController(FormDataContext db, SerialNumberRepo numberRepo)
        {
            this.db = db;
            this.numberRepo = numberRepo;
            rules = new DrawRules(numberRepo.Get(), db.Forms.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //Take viewdata from Razor page
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            //Checking if there is entered a searchstring
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            //Taking viewdata from razor page
            ViewData["CurrentFilter"] = searchString;
            //Take all the forms from database as queryable
            var forms = db.Forms.AsQueryable();
            //If we have a search string, get the names that contain the searchstring
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.LastName.Contains(searchString)
                                       || f.FirstName.Contains(searchString));
            }
            //Arrange sortorder, if not any of the cases, we go to default
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
            //Pagesize default is 10, so we take 10 items and show them on the page
            int pageSize = 10;
            return View(await PaginatedList<Form>.CreateAsync(forms, pageNumber ?? 1, pageSize));

        }
        public IActionResult CreateNumbers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNumbers(int count)
        {
            numberRepo.Create(count);
            return RedirectToAction("Numbers");
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
            if (!rules.CheckRules(p.SerialNumber))
            {
                ModelState.AddModelError("", "Serialnumber is not valid");
                return View();
            }
            //Checking if serialnumber is already used twice and sending error to user if its used
            if (!rules.CheckRules(p.SerialNumber))
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
    }
}
