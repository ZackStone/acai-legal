using System.ComponentModel.DataAnnotations;
using AcaiLegal.Domain.Entities.Validators;

namespace AcaiLegal.Domain.Entities
{
    public class Tamanho : BaseEntity
    {

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Label { get; set; }

        [Required]
        [NotDefault]
        public int TamanhoMl { get; set; }

        [Required]
        [NotDefault]
        public decimal Preco { get; set; }

        [Required]
        [NotDefault]
        public int TempoDePreparo { get; set; }
    }
}