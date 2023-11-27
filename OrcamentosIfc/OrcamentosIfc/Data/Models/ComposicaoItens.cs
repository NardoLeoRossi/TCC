using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrcamentosIfc.Data.Interfaces;
using Xbim.Ifc2x3.GeometricConstraintResource;

namespace OrcamentosIfc.Data.Models
{
    public class ComposicaoItens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Codigo { get; set; }

        [MaxLength(100)]
        public string ItemTipo { get; set; }

        [MaxLength(100)]
        public string ComposicaoCodigoComposicao { get; set; }

        public decimal ItemCoeficiente { get; set; }

        public decimal ItemPrecoUnitario { get; set; }

        public decimal ItemCustoTotal { get; set; }

        [MaxLength(20)]
        public string Prefixo { get; set; }

        public void LoadObjetos()
        {
            if (ItemTipo.ToUpper().Equals("INSUMO"))
            {
                Insumo = Parametros.AppDbContext.Insumos.FirstOrDefault(i => i.Codigo == ComposicaoCodigoComposicao && i.Prefixo == Prefixo); 
            }
            else
            {
                Composicao = Parametros.AppDbContext.Composicoes.FirstOrDefault(c => c.CodigoComposicao == ComposicaoCodigoComposicao && c.Prefixo == Prefixo);
            }
        }

        [NotMapped]
        public Composicao Composicao;

        [NotMapped]
        public Insumo Insumo;

        [NotMapped]
        public string ItemDescricao
        {
            get
            {
                if (ItemTipo.ToUpper().Equals("INSUMO"))
                    return Insumo.Descricao;
                else
                    return Composicao.DescricaoComposicao;
            }
        }

        [NotMapped]
        public string ItemUnidade
        {
            get
            {
                if (ItemTipo.ToUpper().Equals("INSUMO"))
                    return Insumo.Unidade;
                else
                    return Composicao.Unidade;
            }
        }
    }
}
