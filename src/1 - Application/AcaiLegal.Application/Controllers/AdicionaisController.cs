using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcaiLegal.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionaisController : BaseController<Adicional, IService<Adicional>>
    {
        public AdicionaisController(IService<Adicional> service) : base(service) { }
    }
}