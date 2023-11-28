﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrcamentosIfc;

namespace OrcamentosIfc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231125195033_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("OrcamentosIfc.Data.Models.Composicao", b =>
                {
                    b.Property<string>("CodigoComposicao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("CodigoAgrupador")
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

                    b.HasKey("CodigoComposicao");

                    b.ToTable("Composicoes");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.ComposicaoItens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ComposicaoCodigoComposicao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<decimal>("ItemCoeficiente")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ItemCustoTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ItemPrecoUnitario")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemTipo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Prefixo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("ComposicoesItens");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.ElementoComposicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ComposicaoCodigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Dimensao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ElementoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prefixo")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(12, 6)");

                    b.HasKey("Id");

                    b.ToTable("ElementoComposicao");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.ElementoInsumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dimensao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ElementoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InsumoCodigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefixo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(12, 6)");

                    b.HasKey("Id");

                    b.ToTable("ElementoInsumo");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.ElementoProjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IfcId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("NomeElementoIfc")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ElementosProjeto");
                });

            modelBuilder.Entity("OrcamentosIfc.Data.Models.Insumo", b =>
                {
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

                    b.HasKey("Codigo");

                    b.ToTable("Insumos");
                });
#pragma warning restore 612, 618
        }
    }
}