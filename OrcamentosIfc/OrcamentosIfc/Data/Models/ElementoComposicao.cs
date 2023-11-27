using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Data.Models
{
    public class ElementoComposicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ElementoId { get; set; }

        [Required]
        public string ComposicaoCodigo{ get; set; }

        [Required]
        public string Dimensao { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 6)")]
        public decimal Quantidade { get; set; }

        [NotMapped]
        public ElementoProjeto ElementoProjeto { get; set; }

        [NotMapped]
        public Composicao Composicao { get; set; }

        public void LoadComposicao()
        {
            Composicao = Parametros.AppDbContext.Composicoes.FirstOrDefault(c => c.CodigoComposicao == ComposicaoCodigo
                                                                                && c.Prefixo == Parametros.PeriodoSinapiSelecionado);
        }
    }
}
