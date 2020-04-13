using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiLegal.Domain.DTO;
using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Repositories;
using AcaiLegal.Domain.Interfaces.Services;

namespace AcaiLegal.Service.Services
{
    public class PedidosService : BaseService<Pedido>, IPedidosService
    {
        private readonly IPedidosRepository _pedidoRepository;

        private readonly IService<Tamanho> _tamanhoService;
        private readonly IService<Sabor> _saborService;
        private readonly IService<Adicional> _adicionalService;

        public PedidosService(IPedidosRepository pedidoRepository,
            IService<Tamanho> tamanhoService, IService<Sabor> saborService, IService<Adicional> adicionalService
            ) : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;

            _tamanhoService = tamanhoService;
            _saborService = saborService;
            _adicionalService = adicionalService;
        }

        public override Task<List<Pedido>> GetAll() => _pedidoRepository.GetAll();

        public override Task<Pedido> Get(Guid id) => _pedidoRepository.Get(id);

        public Pedido Checkout(PedidoDTO dto)
        {
            Pedido pedido = new Pedido()
            {
                TamanhoId = dto.TamanhoId,
                SaborId = dto.SaborId,
                Adicionais = dto.Adicionais?.Select(a => new PedidoAdicional() { AdicionalId = a }).ToList()
            };

            var tamanhoTask = _tamanhoService.Get(pedido.TamanhoId);
            var saborTask = _saborService.Get(pedido.SaborId);
            var adicionaisTask = _adicionalService.GetAll();

            Task.WaitAll(new Task[] { tamanhoTask, saborTask, adicionaisTask });

            var tamanho = tamanhoTask.Result;
            var sabor = saborTask.Result;
            var adicionais = adicionaisTask.Result.Where(a => dto.Adicionais?.Any(x => x == a.Id) ?? false);

            pedido.PrecoTotal = tamanho.Preco + (adicionais?.Sum(a => a.Preco ?? 0) ?? 0);
            pedido.TempoDePreparo = tamanho.TempoDePreparo
                + (sabor.TempoDePreparo ?? 0)
                + (adicionais?.Sum(a => a.TempoDePreparo ?? 0) ?? 0);

            return pedido;
        }

        public Task<Pedido> PostDTO(PedidoDTO dto)
        {
            var pedido = Checkout(dto);
            return base.Post(pedido);
        }
    }
}