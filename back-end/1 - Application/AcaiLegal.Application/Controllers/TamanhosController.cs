using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcaiLegal.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TamanhosController : BaseController<Tamanho, IService<Tamanho>>
    {
        public TamanhosController(IService<Tamanho> service) : base(service) { }
    }
}