using DenounceBeasts.Application.Dtos.Sectors;
using DenounceBeasts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private static readonly List<Sector> _sectors = new List<Sector>
        {
            new Sector { Id = 1, Name = "Santo Domingo", PostalCode = "10101", IsActive = true,
             MunicipalityId = 1},
            new Sector { Id = 2, Name = "Santiago de los Caballeros", PostalCode = "51000", IsActive = true,  MunicipalityId =1},
            new Sector { Id = 3, Name = "Puerto Plata", PostalCode = "57000", IsActive = true, MunicipalityId=2 }
        };

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sector = _sectors.FirstOrDefault(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }
            return Ok(sector);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sectorsDto = _sectors.Select(m => new SectorDto
            {
                Id = m.Id,
                Name = m.Name,
                PostalCode = m.PostalCode,
                MunicipalityId = m.MunicipalityId
            }).ToList();
            return Ok(sectorsDto);
        }

        [HttpPost]
        public IActionResult Create(Sector sector)
        {
            if (string.IsNullOrWhiteSpace(sector.Name))
            {
                return BadRequest("Name of sector is required.");
            }
            int newId = _sectors.Any() ? _sectors.Max(m => m.Id) + 1 : 1;
            sector.Id = newId;
            if (sector.IsActive == false)
            {
                sector.IsActive = true;
            }

            _sectors.Add(sector);

            return Ok(sector);


        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sector sector)
        {
            var existing = _sectors.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Name = sector.Name;
            existing.PostalCode = sector.PostalCode;
            existing.IsActive = sector.IsActive;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _sectors.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _sectors.Remove(existing);
            return NoContent();


        }

    }
}
