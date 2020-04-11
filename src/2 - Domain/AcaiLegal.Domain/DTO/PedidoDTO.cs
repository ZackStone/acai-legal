using System;

namespace AcaiLegal.Domain.DTO
{
    public class PedidoDTO
    {
        public Guid TamanhoId { get; set; }

        public Guid SaborId { get; set; }

        public Guid[] Adicionais { get; set; }
    }
}