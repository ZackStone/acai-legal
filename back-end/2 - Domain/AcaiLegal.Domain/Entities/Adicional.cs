using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcaiLegal.Domain.Entities
{
    public class Adicional : BaseEntity
    {
        public Adicional()
        {
            Pedidos = new HashSet<PedidoAdicional>();
        }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Label { get; set; }

        public decimal? Preco { get; set; }

        public int? TempoDePreparo { get; set; }

        [JsonIgnore]
        public ICollection<PedidoAdicional> Pedidos { get; set; }
    }
}