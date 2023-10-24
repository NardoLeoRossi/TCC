﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrcamentosIfc;

namespace OrcamentosIfc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("OrcamentosIfc.Data.Models.ComposicaoAnalitica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoAgrupador")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("CodigoComposicao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<decimal>("CustoTotal")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoAgrupador")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("DescricaoClasse")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("DescricaoComposicao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("DescricaoTipo1")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ItemCodigo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<decimal>("ItemCoeficiente")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ItemCustoTotal")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemDescricao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("ItemOrigemPreco")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<decimal>("ItemPrecoUnitario")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemTipo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ItemUnidade")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("OrigemPreco")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Prefixo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("SiglaClasse")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("SiglaTipo1")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("Vinculo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ComposicoesAnaliticas");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.ComposicaoSintetica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoAgrupador")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("CodigoComposicao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<decimal>("CustoTotal")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoAgrupador")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("DescricaoClasse")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("DescricaoComposicao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("DescricaoTipo1")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("OrigemPreco")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Prefixo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("SiglaClasse")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("SiglaTipo1")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("Vinculo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ComposicoesSinteticas");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.Insumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("OrigemPreco")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefixo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Insumos");
                });
#pragma warning restore 612, 618
        }
    }
}
