using DenounceBeasts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        private static readonly List<Municipality> _municipalities = new List<Municipality>
        {
            new Municipality { Id = 1, Name = "Santo Domingo", PostalCode = "10101", IsActive = true },
            new Municipality { Id = 2, Name = "Santiago de los Caballeros", PostalCode = "51000", IsActive = true },
            new Municipality { Id = 3, Name = "Puerto Plata", PostalCode = "57000", IsActive = true }
        };


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var municipality = _municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            return Ok(municipality);
        }


        [HttpGet]
        // public ActionResult<List<Municipality>> GetMunicipalities()
        public IActionResult GetMunicipalities()
        {
            

            return Ok(_municipalities);
            // return (municipalities);
        }

        [HttpGet("getMunicipalities")]
        // public ActionResult<List<Municipality>> GetMunicipalities()
        public IActionResult GetMunicipalitiesx()
        {
            // Placeholder implementation
            var municipalities = new List<Municipality>
            {
                new Municipality{ Id = 1, Name = "Springfield", PostalCode = "12345", IsActive = true },
                new Municipality{ Id = 2, Name = "Shelbyville", PostalCode = "67890", IsActive = false }
            };

            var muns = new List<Municipality>();
            muns.Add(new Municipality { Id = 1, Name = "City A", PostalCode = "10001", IsActive = true });
            muns.Add(new Municipality { Id = 1, Name = "City A", PostalCode = "10001", IsActive = true });

            return Ok(municipalities);
            // return (municipalities);
        }
        [HttpGet("/getMunicipalities")]
        // public ActionResult<List<Municipality>> GetMunicipalities()
        public IActionResult GetMunicipalitiesxc()
        {
            // Placeholder implementation
            var municipalities = new List<Municipality>
            {
                new Municipality{ Id = 1, Name = "Springfield", PostalCode = "12345", IsActive = true },
                new Municipality{ Id = 2, Name = "Shelbyville", PostalCode = "67890", IsActive = false }
            };

            var muns = new List<Municipality>();
            muns.Add(new Municipality { Id = 1, Name = "City A", PostalCode = "10001", IsActive = true });
            muns.Add(new Municipality { Id = 1, Name = "City A", PostalCode = "10001", IsActive = true });

            return Ok(municipalities);
            // return (municipalities);
        }


        [HttpPost] // POST: api/municipalities
        public IActionResult Create(Municipality municipality)
        {
            // Validación manual adicional: nombre no vacío (alternativa a [Required]).
            if (string.IsNullOrWhiteSpace(municipality.Name))
            {
                return BadRequest("Name of municipality is required.");
            }
            int newId = _municipalities.Any() ? _municipalities.Max(m => m.Id) + 1 : 1;
            municipality.Id = newId;
            if (municipality.IsActive == false)
            {
                // Por lógica de negocio, podríamos decidir que todo nuevo municipio inicia activo.
                municipality.IsActive = true;
            }

            _municipalities.Add(municipality);
            // Devolver respuesta 201 Created con el recurso creado
            ////return CreatedAtAction(
            ////    nameof(GetById),              // Nombre de la acción para generar el link de detalle
            ////    new { id = municipality.Id }, // Valores de ruta (el id del nuevo recurso)
            ////    municipality                  // El objeto creado (en el cuerpo de la respuesta)
            ////);
            
            return Ok(_municipalities);
            

        }

        [HttpPut("{id}")] // PUT: api/municipalities/5
        public IActionResult Update(int id, Municipality municipality)
        {
            var existing = _municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            // Opcional: validar que municipality.Id == id si quisiéramos forzar consistencia.
            // Actualizar propiedades (excepto el Id)
            existing.Name = municipality.Name;
            existing.PostalCode = municipality.PostalCode;
            existing.IsActive = municipality.IsActive;
            // Retornar 204 NoContent indicando que se realizó la operación sin devolver cuerpo.
            return Ok(_municipalities);
        }

        [HttpDelete("{id}")] // DELETE: api/municipalities/5
        public IActionResult Delete(int id)
        {
            var existing = _municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _municipalities.Remove(existing);
            // Retornamos 204 NoContent para indicar que se eliminó correctamente (sin contenido).
            return Ok(_municipalities);

        }

    }
}
