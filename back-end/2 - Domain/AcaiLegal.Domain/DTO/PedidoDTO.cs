using System;
using System.ComponentModel.DataAnnotations;
using AcaiLegal.Domain.Entities.Validators;

namespace AcaiLegal.Domain.DTO
{
    public class PedidoDTO
    {
        [Required]
        [NotEmpty]
        public Guid TamanhoId { get; set; }

        [Required]
        [NotEmpty]
        public Guid SaborId { get; set; }

        public Guid[] Adicionais { get; set; }
    }
}