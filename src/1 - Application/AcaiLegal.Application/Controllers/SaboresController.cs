using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcaiLegal.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaboresController : BaseController<Sabor, IService<Sabor>>
    {
        public SaboresController(IService<Sabor> service) : base(service) { }
    }
}