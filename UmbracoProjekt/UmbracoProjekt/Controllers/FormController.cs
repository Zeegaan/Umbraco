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
            //Pagesize default is 3, so we take 3 items and show them on the page
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
            //Loop through all serialnumbers in repo, check if it already exists.
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
            //making new empty list of string
            List<string> usedNumbers = new List<string>();

            foreach (var form in db.Forms)
            {
                //check if the serial numbers match, if they do, add them to the UsedNumbers list
                if (form.SerialNumber == serialNumber)
                {
                    usedNumbers.Add(form.SerialNumber);
                }
                //Check if we already have 2 numbers in the database, if yes, return false.
                if (usedNumbers.Count == 2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
