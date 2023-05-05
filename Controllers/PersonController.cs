using API_Models;
using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson<Person> _api;
        public PersonController(IPerson<Person> api)
        {
            this._api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _api.GetAllPersons());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error 500: failed to retrive data from database");
            }
        }

        [HttpGet("{id:int}/person")]
        public async Task<IActionResult> GetPersonInterest(int id)
        {
            try
            {
                return Ok(await _api.GetPersonById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error 500: failed to retrive data from database");
            }
        }
    }
}
