using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrcamentosIfc.Data;
using OrcamentosIfc.Data.Models;

namespace OrcamentosIfc
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = " + AppConfiguration.GetDataBasePath());
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Insumo> Insumos { get; set; }

        public DbSet<ComposicaoSintetica> ComposicoesSinteticas { get; set; }

        public DbSet<ComposicaoAnalitica> ComposicoesAnaliticas { get; set; }

        public DbSet<ElementoProjeto> ElementosProjeto { get; set;}

        public DbSet<ElementoComposicaoAnalitica> ElementoComposicaoAnalitica { get; set; }

        public DbSet<ElementoComposicaoSintetica> ElementoComposicaoSintetica { get; set; }

        public DbSet<ElementoInsumo> ElementoInsumo { get; set; }

        public DbSet<VisaoGrafica> ItensVisaoGrafica { get; set; }

    }
}
