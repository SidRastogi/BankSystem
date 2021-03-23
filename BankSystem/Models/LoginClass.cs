using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage = "Please Enter The Email ...")]
        [Display(Name = "Email")]
        public string Uemail { get; set; }

        [Required(ErrorMessage = "Please Enter The Password ...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }
    }
}
