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
        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Nome_Projeto { get; set; }

        public string Nome_Elemento { get; set; }

        public string Descricao_Item_Sinapi { get; set; }

        public string Unidade { get; set; }

        public string Dimensao_Associada { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Preco_Unitario { get; set; }

        public decimal Preco_Total { get; set; }

    }
}
