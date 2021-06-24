using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api5.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }
        public string Emp_FirstName { get; set; }
        public string Emp_LastName { get; set; }
        public int Age { get; set; }
        public int Emp_Building_ID { get; set; }
    }
}
