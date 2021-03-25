using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankSystem.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;


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
        [Route("Registration")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Registration")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistrationClass uc)
        {
            MailMessage mm = new MailMessage(BankSystem.Properties.Resources.form, uc.Uemail);
            mm.Subject = "test";
            mm.Body = "hello";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            NetworkCredential nc = new NetworkCredential(BankSystem.Properties.Resources.email, BankSystem.Properties.Resources.password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = nc;
            smtp.Send(mm);

            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The User " + uc.UserName + " Is Saved Successfully ...!";
            return View();
        }

        [HttpGet]
        [Route("Verification/{email}")]
        public IActionResult EmailVerification(string email)
        {
            ViewBag.Data = "sajskhakshj" + email;
           
           
            return View();
        }
    }
}
