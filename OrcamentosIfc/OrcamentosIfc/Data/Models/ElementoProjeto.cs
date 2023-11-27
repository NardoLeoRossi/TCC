using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrcamentosIfc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OrcamentosIfc.Data.Models
{
    public class ElementoProjeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string NomeProjeto { get; set; }

        [Required]
        [MaxLength(255)]
        public string IfcId { get; set; }

        [Required]
        [MaxLength(255)]
        public string NomeElementoIfc{ get; set; }

        [NotMapped]
        public List<ElementoComposicao> Composicoes { get; set; }

        [NotMapped]
        public List<ElementoInsumo> Insumos { get; set; }

        public void AddItemCusto(IItemSinapi item, string dimensao, decimal qntd)
        {
            if (item is Composicao)
            {
                AddItemCustoComposicaoSintetica(item as Composicao, dimensao, qntd);
            }
            else if (item is Insumo)
            {
                AddItemCustoInsumo(item as Insumo, dimensao, qntd);
            }
        }

        private void AddItemCustoComposicaoSintetica(Composicao item, string dimensao, decimal qntd)
        {
            var custo = new ElementoComposicao
            {
                Quantidade = qntd,
                ComposicaoCodigo = item.CodigoComposicao,
                ElementoId = this.Id,
                Dimensao = dimensao
            };
            Parametros.AppDbContext.ElementoComposicao.Add(custo);
            Parametros.AppDbContext.SaveChanges();
        }

        private void AddItemCustoInsumo(Insumo item, string dimensao, decimal qntd)
        {
            var custo = new ElementoInsumo
            {
                Quantidade = qntd,
                InsumoCodigo = item.Codigo,
                ElementoId = this.Id,
                Dimensao = dimensao
            };
            Parametros.AppDbContext.ElementoInsumo.Add(custo);
            Parametros.AppDbContext.SaveChanges();
        }

        public void RemoveCusto(object item)
        {
            if (item is ElementoComposicao)
            {
                Parametros.AppDbContext.ElementoComposicao.Remove(item as ElementoComposicao);
            }
            else if (item is ElementoInsumo)
            {
                Parametros.AppDbContext.ElementoInsumo.Remove(item as ElementoInsumo);
            }
            Parametros.AppDbContext.SaveChanges();
        }

        public void LoadCustos()
        {
            Composicoes = Parametros.AppDbContext.ElementoComposicao.Where(x => x.ElementoId == this.Id).ToList();

            Composicoes.ForEach(x => x.LoadComposicao());

            Insumos = Parametros.AppDbContext.ElementoInsumo.Where(x => x.ElementoId == this.Id).ToList();

            Insumos.ForEach(x => x.LoadInsumo());
        }
    }
}