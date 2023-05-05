using API_Models;
using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IInterest<Interest> _api;

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            return Ok(await _api.GetAllInterests());
        }

        public InterestController(IInterest<Interest> api) : base()
        {
            _api = api;
        }

        [HttpPost("{interestName:length(1, 50)}/{interestDescription:length(1, 50)}")]
        public async Task<IActionResult> AddInterest(string interestName, string interestDescription)
        {
            return Ok(await _api.AddInterest(interestName, interestDescription));
        }
    }
}
