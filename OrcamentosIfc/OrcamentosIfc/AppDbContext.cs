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
        }

        public DbSet<Insumo> Insumos { get; set; }

        public DbSet<ComposicaoSintetica> ComposicoesSinteticas { get; set; }

        public DbSet<ComposicaoAnalitica> ComposicoesAnaliticas { get; set; }


    }
}
