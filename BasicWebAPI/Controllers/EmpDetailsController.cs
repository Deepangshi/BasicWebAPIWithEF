using BasicWebAPI.Context;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDetailsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public EmpDetailsController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployeeDetails()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        // GET: api/EmployeeDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeDetails(int id)
        {
            var empdetails = await _context.EmployeeDetails.FindAsync(id);

            if (empdetails == null)
            {
                return NotFound();
            }

            return empdetails;
        }

        // PUT: api/EmployeeDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetails(int id, EmployeeDetails empdetails)
        {
            if (id != empdetails.EmployeeDetailsID)
            {
                return BadRequest();
            }

            _context.Entry(empdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //204 No Content
        }

        // POST: api/EmployeeDetail
        [HttpPost]
        public async Task<ActionResult<EmployeeDetails>> PostEmployeeDetails(EmployeeDetails empdetails)
        {
            _context.EmployeeDetails.Add(empdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDetails", new { id = empdetails.EmployeeDetailsID }, empdetails);
        }

        // DELETE: api/EmployeeDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetails(int id)
        {
            var empdetails = await _context.EmployeeDetails.FindAsync(id);
            if (empdetails == null)
            {
                return NotFound();
            }

            _context.EmployeeDetails.Remove(empdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDetailsExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EmployeeDetailsID == id);
        }
    }
}
