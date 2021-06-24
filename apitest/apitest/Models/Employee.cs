using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apitest.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }
        public string Emp_FirstName { get; set; }
        public string Emp_LastName { get; set; }
        public int Emp_Age { get; set; }
        public int Emp_Building_ID { get; set; }
    }
}
