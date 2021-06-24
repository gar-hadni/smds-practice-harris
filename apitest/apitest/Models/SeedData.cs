using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apitest.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TestDbContext>>()))
            {
                // Employee table empty
                if (!context.Employee.Any()) 
                {
                    context.Employee.AddRange(
                        new Employee
                        {
                            Emp_FirstName = "Harris",
                            Emp_LastName = "Adni",
                            Emp_Age = 25,
                            Emp_Building_ID = 1
                        },

                        new Employee
                        {
                            Emp_FirstName = "Haniff",
                            Emp_LastName = "Adni",
                            Emp_Age = 23,
                            Emp_Building_ID = 2
                        },

                        new Employee
                        {
                            Emp_FirstName = "Firstname",
                            Emp_LastName = "Lastname",
                            Emp_Age = 20,
                            Emp_Building_ID = 3
                        }
                    );
                }
                // Building table empty
                else if (!context.Building.Any()) 
                {
                    context.Building.AddRange(
                        new Building
                        {
                            Building_ID = 1,
                            Building_Name = "Kulim 1",
                            Building_Short = "KM1"
                        },

                        new Building
                        {
                            Building_ID = 2,
                            Building_Name = "Kulim 2",
                            Building_Short = "KM2"
                        },

                        new Building
                        {
                            Building_ID = 3,
                            Building_Name = "Penang 12",
                            Building_Short = "PG12"
                        }
                    );
                }
                // Look for any data.
                if (context.Employee.Any() && context.Building.Any())
                {
                    return;   // DB has been seeded
                }

                
                context.SaveChanges();
            }
        }
    }
}
