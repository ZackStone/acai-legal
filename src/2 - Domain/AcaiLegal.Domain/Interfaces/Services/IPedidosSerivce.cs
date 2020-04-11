using System.Threading.Tasks;
using AcaiLegal.Domain.DTO;
using AcaiLegal.Domain.Entities;

namespace AcaiLegal.Domain.Interfaces.Services
{
    public interface IPedidosService : IService<Pedido>
    {
        Task<Pedido> PostDTO(PedidoDTO dto);
     }
}