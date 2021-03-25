using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSystem.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BankSystem.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // Get: Account 
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = BankSystem.Properties.Resources.ConnectionString;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Verify(LoginClass acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * from UsersReg where Uemail = '" + acc.Uemail+"' and Pwd ='"+acc.Pwd+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
               /* HttpContext.Session.SetString("UserId", dr['UserId'].ToString());*/
                HttpContext.Session.SetString("UserName", dr.GetString(1));
                HttpContext.Session.SetString("Email", dr.GetString(3));
                con.Close();
                return View("Success");
            }
            else
            {
                con.Close();
                return View("Error");
            }
           
            return View();
        }
    }
}
