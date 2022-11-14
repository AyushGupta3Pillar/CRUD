using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CRUD_WITH_EF.Models
{
    public class NewEmployee
    {
        [Key]
        public int Empid { get; set; }

        public string Empname { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }
    }
}
