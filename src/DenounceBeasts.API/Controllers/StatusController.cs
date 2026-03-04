using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infrastructure.Repositories;
using DenounceBeasts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly GenericRepository<Status> _statusRepository;

        public StatusController(GenericRepository<Status> statusRepository)
        {
            this._statusRepository = statusRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _statusRepository.GetById(id);
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
            var statusDto = _statusRepository.GetAll().Select(m => new StatusDto
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

            _statusRepository.Add(status);

            return Ok(new { Id = status.Id });


        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, StatusDto statusRequest)
        {
            var existing = _statusRepository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = statusRequest.Name;

            _statusRepository.Update(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _statusRepository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            _statusRepository.Delete(id);
            return NoContent();


        }

    }
}
