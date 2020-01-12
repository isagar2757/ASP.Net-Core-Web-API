using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly ISampleServices _vinNoService;
        public DetailsController(ISampleServices vinNoService)
        {
            _vinNoService = vinNoService;
        }

        // GET: api/Details
        [HttpGet()]
        [Route("alldetails")]
        [ProducesResponseType(typeof(IEnumerable<Details>), 200)]
        public Task<IEnumerable<Details>> GetDetailsAsync() => _vinNoService.GetAllAsync();

        // GET api/Details/guid
        [HttpGet("{id}", Name = nameof(GetDetailsByIdAsync))]
        [ProducesResponseType(typeof(Details), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDetailsByIdAsync(Guid id)
        {
            Details detail = await _vinNoService.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(detail);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(Details), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostDetailsAsync([FromBody]Details detail)
        {
            if (detail == null)
            {
                return BadRequest();
            }
            await _vinNoService.AddAsync(detail);
            return CreatedAtRoute(nameof(GetDetailsByIdAsync),
              new { id = detail.Id }, detail);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutDetailsAsync(Guid id, [FromBody]Details detail)
        {
            if (detail == null || id != detail.Id)
            {
                return BadRequest();
            }
            if (await _vinNoService.FindAsync(id) == null)
            {
                return NotFound();
            }
            await _vinNoService.UpdateAsync(detail);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id) => await _vinNoService.RemoveAsync(id);

    }
}