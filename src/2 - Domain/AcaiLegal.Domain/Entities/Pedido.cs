using System;
using System.Collections.Generic;

namespace AcaiLegal.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido()
        {
            Adicionais = new HashSet<PedidoAdicional>();
        }

        public Guid TamanhoId { get; set; }

        public Tamanho Tamanho { get; set; }

        public Guid SaborId { get; set; }

        public Sabor Sabor { get; set; }

        public ICollection<PedidoAdicional> Adicionais { get; set; }

        public int TempoDePreparo { get; set; }

        public decimal PrecoTotal { get; set; }
    }
}