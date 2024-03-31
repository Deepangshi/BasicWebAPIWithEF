using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        [HttpGet]
        public string Greetings()
        {
            return "Happy Coding!";
        }

        //returntype
        //Specific Type : int, string, new class()
        //IActionResult: if return OK("Hello!"); else return NoContent();
        //ActionResult<T>: <string>

        // CRUD
        // Create - adding a new record - POST
        // Read - retrieve a single/ list of record(s) - GET
        // Update - modify/edit an existing record - PUT/PATCH(update part of the record)
        // Delete - remove an existing record - DELETE
    }
}
