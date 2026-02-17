using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintTypesController : BaseCatalogController<ComplaintType>
    {
        //private readonly DenounceBeastsContext _context;

        //public ComplaintTypesController(DenounceBeastsContext context)
        //{
        //    this._context = context;
        //}
        public ComplaintTypesController(DenounceBeastsContext context): base(context)
        {
          //this._context = context; 
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var complaintType = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
        //    if (complaintType == null)
        //    {
        //        return NotFound();
        //    }
        //    var result = new ComplaintTypeDto
        //    {
        //        Id = complaintType.Id,
        //        Name = complaintType.Name
        //    };
        //    return Ok(result);
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var complaintTypesDto = _context.ComplaintTypes.Select(m => new ComplaintTypeDto
        //    {
        //        Id = m.Id,
        //        Name = m.Name, 
        //    }).ToList();

        //    return Ok(complaintTypesDto);
        //}



        //[HttpPost]
        //public IActionResult Create(ComplaintTypeDto complaintTypeRequest)
        //{
        //    if (string.IsNullOrWhiteSpace(complaintTypeRequest.Name))
        //    {
        //        return BadRequest("Name of complaintType is required.");
        //    }

        //    var complaintType = new ComplaintType
        //    {
        //        Name = complaintTypeRequest.Name 
        //    };

        //    _context.Add(complaintType);
        //    _context.SaveChanges();

        //    return Ok(new { Id = complaintType.Id });


        //}

        //[HttpPut("{id}")] // PUT: api/complaintTypes/5
        //public IActionResult Update(int id, ComplaintTypeDto complaintTypeRequest)
        //{
        //    var existing = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }

        //    existing.Name = complaintTypeRequest.Name; 

        //    _context.Update(existing);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existing = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Remove(existing);
        //    _context.SaveChanges();
        //    return NoContent();


        //}

    }
}
