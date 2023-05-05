using API_Models;
using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Labb_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ILink<Link> _api;

        public LinkController(ILink<Link> api) : base()
        {
            this._api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            return Ok(await _api.GetAllLinks());
        }

        [HttpGet("{id:int}/interest")]
        public async Task<IActionResult> GetInterestByPersonId(int id)
        {
            var result = await _api.GetInterestByPersonId(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/links")]
        public async Task<IActionResult> GetLinksByPersonId(int id)
        {
            var result = await _api.GetLinksByPersonId(id);
            return Ok(result);
        }

        [HttpPost("person/{personId:int}link/{linkId:int}interestName/{interestName:length(1,50)}")]
        public async Task<IActionResult> AddInterestToPersonByPersonId(int linkId, int personId, string interestName)
        {
            var result = await _api.AddInterestToPersonByPersonId(linkId, personId, interestName);
            return Ok(result);
        }

        [HttpPost("person/{PersonId:int}interest/{InterestId:int}url/{URL:length(1,50)}")]
        public async Task<IActionResult> AddLinkForPersonById(int PersonId, int InterestId, string URL)
        {
            var result = await _api.AddLinkForPersonById(PersonId, InterestId, URL);
            return Ok(result);
        }
    }
}
