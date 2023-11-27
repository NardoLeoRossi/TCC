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

        public DbSet<Composicao> Composicoes { get; set; }

        public DbSet<ComposicaoItens> ComposicoesItens { get; set; }

        public DbSet<ElementoProjeto> ElementosProjeto { get; set;}

        public DbSet<ElementoComposicao> ElementoComposicao { get; set; }

        public DbSet<ElementoInsumo> ElementoInsumo { get; set; }

        public DbSet<VisaoGrafica> ItensVisaoGrafica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisaoGrafica>().HasNoKey();
        }
    }
}
