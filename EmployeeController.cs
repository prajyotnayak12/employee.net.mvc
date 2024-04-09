using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees = new List<Employee>
    {
        new Employee { EmployeeId = 1, Name = "Manas", Position = "JD", Salary = 60000, JoinDate = new DateTime(2024, 5, 15) },
        new Employee { EmployeeId = 2, Name = "Rajat", Position = "Hr", Salary = 55000, JoinDate = new DateTime(2024, 5, 10) },
        new Employee { EmployeeId = 3, Name = "Ashutosh", Position = "SD", Salary = 50000, JoinDate = new DateTime(2024, 5, 20) },
        new Employee { EmployeeId = 4, Name = "Rakesh", Position = "Marketing", Salary = 48000, JoinDate = new DateTime(2024, 5, 5) },
        new Employee { EmployeeId = 5, Name = "Saloni", Position = "Sd", Salary = 52000, JoinDate = new DateTime(2024, 5, 1) }
    };

        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employees);
        }

        [HttpGet]
        [Route("GetSecondHighestSalaryEmployee")]
        public IActionResult GetSecondHighestSalaryEmployee()
        {
            var secondHighest = _employees.OrderByDescending(e => e.Salary).Skip(1).FirstOrDefault();
            if (secondHighest != null)
            {
                return Ok(secondHighest);
            }
            return NotFound("No employee with the second highest salary found.");
        }
    }
}
