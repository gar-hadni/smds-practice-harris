using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apitest.Models;
using Microsoft.Data.SqlClient;

namespace apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TestDbContext _context;

        public EmployeesController(TestDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            //return await _context.Employee.ToListAsync();

            //var students = context.Students.FromSql("GetStudents 'Bill'").ToList();

            return await _context.Employee.FromSqlRaw("EXEC SP_ALL_EMPLOYEE").ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(int id)
        //public async Task<ActionResult<Employee>> GetEmployee(int id)
        //public async Task<IQueryable<Employee>> GetEmployee (int id)
        {
            //var employee = await _context.Employee.FindAsync(id);

            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //return employee;


            var Emp_ID = new SqlParameter("@Emp_ID", id);
            return  await _context.Employee.FromSqlRaw("EXEC SP_EMPLOYEE_BY_ID @Emp_ID", Emp_ID).ToListAsync();
       
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost("/delete/{id}")] //TODO
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Emp_ID)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        public async Task<ActionResult<IEnumerable<Employee>>> PostEmployee(Employee employee)
        {

            //_context.Employee.Add(employee);
            //await _context.SaveChangesAsync();

            var Emp_FirstName = new SqlParameter("@Emp_FirstName", employee.Emp_FirstName);
            var Emp_LastName = new SqlParameter("@Emp_LastName", employee.Emp_LastName);
            var Emp_Age = new SqlParameter("@Emp_Age", employee.Emp_Age);
            var Emp_Building_ID = new SqlParameter("@Emp_Building_id", employee.Emp_Building_ID);

            var temp = await _context.Employee.FromSqlRaw("EXEC SP_ADD_EMPLOYEE @Emp_FirstName, @Emp_LastName, @Emp_Age, @Emp_Building_ID", Emp_FirstName, Emp_LastName, Emp_Age, Emp_Building_ID).ToListAsync();

            //Console.WriteLine("temp => " + temp.);
            return CreatedAtAction("GetEmployee", new { id = employee.Emp_ID }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Emp_ID == id);
        }
    }
}
