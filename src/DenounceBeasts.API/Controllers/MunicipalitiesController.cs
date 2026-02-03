using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly DenounceBeastsContext _context;

        public MunicipalitiesController(DenounceBeastsContext context)
        {
            this._context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var municipality = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            var result = new MunicipalityDto
            {
                Id = municipality.Id,
                Name = municipality.Name,
                PostalCode = municipality.PostalCode
            };
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var municipalitiesDto = _context.Municipalities.Select(m => new MunicipalityDto
            {
                Id = m.Id,
                Name = m.Name,
                PostalCode = m.PostalCode
            }).ToList();

            return Ok(municipalitiesDto);
        }

        [HttpGet("with-sectors")]
        public IActionResult GetAll()
        {
            var municipalitiesWithSectors = _context.Municipalities
                .Where(m => m.IsActive)
                .Select(m => new MunicipalitiesWithSector()
                { 
                    Id = m.Id,
                    Name = m.Name,
                    PostalCode = m.PostalCode,
                    Sectors = m.Sectors
                        .Where(s => s.IsActive)
                        .Select(s => new SectorDto
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).ToList()
                }).ToList();

            return Ok(municipalitiesWithSectors);
        }

        [HttpPost]
        public IActionResult Create(MunicipalityDto municipalityRequest)
        {
            if (string.IsNullOrWhiteSpace(municipalityRequest.Name))
            {
                return BadRequest("Name of municipality is required.");
            }

            var municipality = new Municipality
            {
                Name = municipalityRequest.Name,
                PostalCode = municipalityRequest.PostalCode,
                IsActive = true
            };

            _context.Add(municipality);
            _context.SaveChanges();

            return Ok(new { Id = municipality.Id });


        }

        [HttpPut("{id}")] // PUT: api/municipalities/5
        public IActionResult Update(int id, MunicipalityDto municipalityRequest)
        {
            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = municipalityRequest.Name;
            existing.PostalCode = municipalityRequest.PostalCode;

            _context.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);
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
