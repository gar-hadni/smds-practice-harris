using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api5.Models
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
