using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankSystem.Controllers
{
    public class UserRegistrationControllers : Controller
    {
        private readonly ApplicationUserClass _auc;

        public UserRegistrationControllers(ApplicationUserClass auc)
        {
            _auc = auc;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistrationClass uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The User " + uc.UserName + " Is Saved Successfully ...!";
            return View();
        }
    }
}
