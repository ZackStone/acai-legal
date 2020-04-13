using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcaiLegal.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TService> : ControllerBase
        where TEntity : BaseEntity
        where TService : IService<TEntity>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return new ObjectResult(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TEntity>> Get(Guid id)
        {
            var entity = await _service.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _service.Put(entity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _service.Post(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var entity = await _service.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

    }
}