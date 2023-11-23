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

        public List<ElementoComposicaoAnalitica> ComposicoesAnaliticas { get; set; }

        public List<ElementoComposicaoSintetica> ComposicoesSinteticas { get; set; }

        public List<ElementoInsumo> Insumos { get; set; }

        public void AddItemCusto(IItemSinapi item, string dimensao, decimal qntd)
        {
            if (item is ComposicaoAnalitica)
            {
                AddItemCustoComposicaoAnalitica(item as ComposicaoAnalitica, dimensao, qntd);
            }
            else if (item is ComposicaoSintetica)
            {
                AddItemCustoComposicaoSintetica(item as ComposicaoSintetica, dimensao, qntd);
            }
            else if (item is Insumo)
            {
                AddItemCustoInsumo(item as Insumo, dimensao, qntd);
            }
        }

        private void AddItemCustoComposicaoAnalitica(ComposicaoAnalitica item, string dimensao, decimal qntd)
        {
            var custo = new ElementoComposicaoAnalitica
            {
                Quantidade = qntd,
                ComposicaoAnaliticaId = item.Id,
                ElementoId = this.Id,
                Dimensao = dimensao                
            };
            Parametros.AppDbContext.ElementoComposicaoAnalitica.Add(custo);
            Parametros.AppDbContext.SaveChanges();
        }

        private void AddItemCustoComposicaoSintetica(ComposicaoSintetica item, string dimensao, decimal qntd)
        {
            var custo = new ElementoComposicaoSintetica
            {
                Quantidade = qntd,
                ComposicaoSinteticaId = item.Id,
                ElementoId = this.Id,
                Dimensao = dimensao
            };
            Parametros.AppDbContext.ElementoComposicaoSintetica.Add(custo);
            Parametros.AppDbContext.SaveChanges();
        }

        private void AddItemCustoInsumo(Insumo item, string dimensao, decimal qntd)
        {
            var custo = new ElementoInsumo
            {
                Quantidade = qntd,
                InsumoId = item.Id,
                ElementoId = this.Id,
                Dimensao = dimensao
            };
            Parametros.AppDbContext.ElementoInsumo.Add(custo);
            Parametros.AppDbContext.SaveChanges();
        }

        public void RemoveCusto(object item)
        {
            if (item is ElementoComposicaoAnalitica)
            {
                Parametros.AppDbContext.ElementoComposicaoAnalitica.Remove(item as ElementoComposicaoAnalitica);
            }
            else if (item is ElementoComposicaoSintetica)
            {
                Parametros.AppDbContext.ElementoComposicaoSintetica.Remove(item as ElementoComposicaoSintetica);
            }
            else if (item is ElementoInsumo)
            {
                Parametros.AppDbContext.ElementoInsumo.Remove(item as ElementoInsumo);
            }
            Parametros.AppDbContext.SaveChanges();
        }

        public void LoadCustos()
        {
            ComposicoesAnaliticas = Parametros.AppDbContext.ElementoComposicaoAnalitica
                                                                .Include(x => x.ComposicaoAnalitica)
                                                                .Where(x => x.ElementoId == this.Id).ToList();

            ComposicoesSinteticas = Parametros.AppDbContext.ElementoComposicaoSintetica
                                                                .Include(x => x.ComposicaoSintetica)
                                                                .Where(x => x.ElementoId == this.Id).ToList();

            Insumos = Parametros.AppDbContext.ElementoInsumo
                                                        .Include(x => x.Insumo)
                                                        .Where(x => x.ElementoId == this.Id).ToList();
        }
    }
}