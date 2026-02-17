using DenounceBeasts.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCatalogController<T> : ControllerBase where T : class
    {
        protected readonly DenounceBeastsContext Context;
        protected readonly DbSet<T> Entity;

        public BaseCatalogController(DenounceBeastsContext context)
        {
            Context = context;
            Entity = context.Set<T>();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = Entity.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entities = Entity.ToList();
            return Ok(entities);

        }
        [HttpPost]
        public IActionResult Create(T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null.");
            }
            Entity.Add(entity);
            Context.SaveChanges();
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null.");
            }
            var existingEntity = Entity.Find(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            Context.Entry(existingEntity).CurrentValues.SetValues(entity);
            Context.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = Entity.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            Entity.Remove(entity);
            Context.SaveChanges();
            return NoContent();
        }
    }
}


