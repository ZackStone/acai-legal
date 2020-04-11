using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcaiLegal.Domain.DTO;
using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcaiLegal.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        protected readonly IPedidosService _service;

        public PedidosController(IPedidosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetAll()
        {
            return new ObjectResult(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Pedido>> Get(Guid id)
        {
            var entity = await _service.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Post(PedidoDTO dto)
        {
            var entity = await _service.PostDTO(dto);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, Pedido entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _service.Put(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Pedido>> Delete(Guid id)
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