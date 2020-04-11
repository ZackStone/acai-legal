using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcaiLegal.Domain.Entities;
using AcaiLegal.Domain.Interfaces.Repositories;
using AcaiLegal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AcaiLegal.Infra.Data.Repository
{
    public class PedidosRepository : BaseRepository<Pedido>, IPedidosRepository
    {
        public PedidosRepository(AcaiLegalContext dbContext) : base(dbContext) { }

        public override Task<List<Pedido>> GetAll() =>
            _dbContext.Pedido
                .Include(p => p.Tamanho)
                .Include(p => p.Sabor)
                .ToListAsync();

        public override Task<Pedido> Get(Guid id) =>
            _dbContext.Pedido
                .Include(p => p.Tamanho)
                .Include(p => p.Sabor)
                .Include(p => p.Adicionais)
                    .ThenInclude(a => a.Adicional)
                .SingleOrDefaultAsync(p => p.Id == id);
    }
}