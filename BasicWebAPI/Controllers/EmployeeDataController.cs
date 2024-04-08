using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeDataController : ControllerBase
    {
        private readonly IEmployeeDataService _employeeDataService;
        public EmployeeDataController(IEmployeeDataService employeeDataService) 
        {
            _employeeDataService = employeeDataService;    
        }
        // GET: api/<EmployeeDataController>
        [HttpGet]
        public List<EmployeeData> Get()
        {
            var empdatas = _employeeDataService.GetEmployeeDatas();
            return empdatas;
        }

        // GET api/<EmployeeDataController>/5
        [HttpGet("{id}")]
        public EmployeeData Get(int id)
        {
            var empd = _employeeDataService.GetEmployeeDatas(id);
            return empd;
        }

        // POST api/<EmployeeDataController>
        [HttpPost]
        public EmployeeData Post([FromBody] EmployeeData employeedata)
        {
            var empd = _employeeDataService.AddEmployee(employeedata);
            return empd;
        }

        // PUT api/<EmployeeDataController>/5
        [HttpPut("{id}")]
        public EmployeeData Put(int id, [FromBody] EmployeeData employeedatas)
        {
            var updated = _employeeDataService.UpdateEmployee(employeedatas);
            return updated;
        }

        // DELETE api/<EmployeeDataController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var isDeleted = _employeeDataService.DeleteEmployee(id);
            return isDeleted;
        }
    }
}
