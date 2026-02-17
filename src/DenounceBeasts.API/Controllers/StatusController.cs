using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly DenounceBeastsContext _context;

        public StatusController(DenounceBeastsContext context)
        {
            this._context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _context.Status.FirstOrDefault(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }
            var result = new StatusDto
            {
                Id = status.Id,
                Name = status.Name
            };
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var statusDto = _context.Status.Select(m => new StatusDto
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            return Ok(statusDto);
        }

     

        [HttpPost]
        public IActionResult Create(StatusDto statusRequest)
        {
            if (string.IsNullOrWhiteSpace(statusRequest.Name))
            {
                return BadRequest("Name of status is required.");
            }

            var status = new Status
            {
                Name = statusRequest.Name
            };

            _context.Add(status);
            _context.SaveChanges();

            return Ok(new { Id = status.Id });


        }

        [HttpPut("{id}")] // PUT: api/status/5
        public IActionResult Update(int id, StatusDto statusRequest)
        {
            var existing = _context.Status.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = statusRequest.Name; 

            _context.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Status.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.Remove(existing);
            _context.SaveChanges();
            return NoContent();


        }

    }
}
