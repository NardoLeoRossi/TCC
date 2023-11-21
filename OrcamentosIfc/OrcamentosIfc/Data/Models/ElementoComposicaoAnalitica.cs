using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Data.Models
{
    public class ElementoComposicaoAnalitica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ElementoId { get; set; }

        [Required]
        public int ComposicaoAnaliticaId { get; set; }

        [Required]
        public string Dimensao { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 6)")]
        public decimal Quantidade { get; set; }

        public ElementoProjeto ElementoProjeto { get; set; }

        public ComposicaoAnalitica ComposicaoAnalitica { get; set; }
    }
}
