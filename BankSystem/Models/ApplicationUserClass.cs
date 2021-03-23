using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace BankSystem.Models
{
    public class ApplicationUserClass:DbContext
    {
        public ApplicationUserClass(DbContextOptions<ApplicationUserClass> options):base(options)
        {

        }

        public DbSet<RegistrationClass> UsersReg { get; set; }
    }
}
