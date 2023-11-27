using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Data.Models
{
    [Table("VisaoGrafica")]
    public class VisaoGrafica
    {
        public string Tipo { get; set; }

        public string NomeProjeto { get; set; }

        public string NomeElementoIfc { get; set; }

        public string Descricao { get; set; }

        public string Unidade { get; set; }

        public string Dimensao { get; set; }

        public decimal? Quantidade { get; set; }

        public decimal? Preco { get; set; }

        public decimal? PrecoTotal { get; set; }

        public string Prefixo { get; set; }
    }
}
