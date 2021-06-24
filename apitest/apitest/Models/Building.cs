using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apitest.Models
{
    public class Building
    {
        [Key]
        public int Building_ID { get; set; }
        public string Building_Name { get; set; }
        public string Building_Short { get; set; }
    }
}
