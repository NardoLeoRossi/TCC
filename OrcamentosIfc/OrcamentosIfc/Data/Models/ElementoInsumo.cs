using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Data.Models
{
    public class ElementoInsumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ElementoId { get; set; }

        [Required]
        public int InsumoId{ get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 6)")]
        public decimal Quantidade { get; set; }

        public ElementoProjeto ElementoProjeto { get; set; }

        public Insumo Insumo { get; set; }  
    }
}
