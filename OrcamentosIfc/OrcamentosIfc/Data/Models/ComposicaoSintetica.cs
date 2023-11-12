using OrcamentosIfc.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Data.Models
{
    public class ComposicaoSintetica : IItemSinapi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string DescricaoClasse { get; set; }

        [MaxLength(100)]
        public string SiglaClasse { get; set; }

        [MaxLength(100)]
        public string DescricaoTipo1 { get; set; }

        [MaxLength(100)]
        public string SiglaTipo1 { get; set; }

        [MaxLength(100)]
        public string CodigoAgrupador { get; set; }

        [MaxLength(100)]
        public string DescricaoAgrupador { get; set; }

        [MaxLength(100)]
        public string CodigoComposicao { get; set; }

        [MaxLength(1000)]
        public string DescricaoComposicao { get; set; }

        [MaxLength(10)]
        public string Unidade { get; set; }

        [MaxLength(100)]
        public string OrigemPreco { get; set; }

        [DataType(DataType.Currency)]
        public decimal CustoTotal { get; set; }

        [MaxLength(100)]
        public string Vinculo { get; set; }

        [MaxLength(20)]
        public string Prefixo { get; set; }
    }
}
