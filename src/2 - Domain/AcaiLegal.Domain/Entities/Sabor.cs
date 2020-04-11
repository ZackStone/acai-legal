using System.ComponentModel.DataAnnotations;

namespace AcaiLegal.Domain.Entities
{
    public class Sabor : BaseEntity
    {

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Label { get; set; }

        public int? TempoDePreparo { get; set; }
    }
}