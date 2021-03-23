using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BankSystem.Models
{
    public class RegistrationClass
    {
        
            [Key]
            public int UserId { get; set; }

            [Required(ErrorMessage = "Please Enter UserName ...")]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Please Enter The Password ...")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Pwd { get; set; }

            [Required(ErrorMessage = "Please Enter The Email ...")]
            [Display(Name = "Email")]
            public string Uemail { get; set; }

            [Required(ErrorMessage = "Please Enter The Gender ...")]
            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Please Enter The Phone ...")]
            [Display(Name = "Phone")]
            public int Phone { get; set; }
      
    }
}
