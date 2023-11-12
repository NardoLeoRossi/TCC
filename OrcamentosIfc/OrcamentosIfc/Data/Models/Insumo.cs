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
    public class Insumo : IItemSinapi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Codigo { get;  set; }

        [MaxLength(255)]
        public string Descricao { get;  set; }

        [MaxLength(10)]
        public string Unidade { get; set; }

        [MaxLength(10)]
        public string OrigemPreco{ get; set; }

        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [MaxLength(20)]
        public string Prefixo { get; set; }
    }
}
