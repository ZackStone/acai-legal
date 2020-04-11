using System.ComponentModel.DataAnnotations;

namespace AcaiLegal.Domain.Entities
{
    public class Tamanho : BaseEntity
    {

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Label { get; set; }

        public int TamanhoMl { get; set; }

        public decimal Preco { get; set; }

        public int TempoDePreparo { get; set; }
    }
}