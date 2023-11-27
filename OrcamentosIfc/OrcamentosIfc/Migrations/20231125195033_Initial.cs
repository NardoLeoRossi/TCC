using Microsoft.EntityFrameworkCore.Migrations;

namespace OrcamentosIfc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Composicoes",
                columns: table => new
                {
                    CodigoComposicao = table.Column<string>(maxLength: 100, nullable: false),
                    DescricaoClasse = table.Column<string>(maxLength: 100, nullable: true),
                    SiglaClasse = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoTipo1 = table.Column<string>(maxLength: 100, nullable: true),
                    SiglaTipo1 = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoAgrupador = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoAgrupador = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoComposicao = table.Column<string>(maxLength: 1000, nullable: true),
                    Unidade = table.Column<string>(maxLength: 10, nullable: true),
                    OrigemPreco = table.Column<string>(maxLength: 100, nullable: true),
                    CustoTotal = table.Column<decimal>(nullable: false),
                    Vinculo = table.Column<string>(maxLength: 100, nullable: true),
                    Prefixo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composicoes", x => new { x.CodigoComposicao, x.Prefixo });
                });

            migrationBuilder.CreateTable(
                name: "ComposicoesItens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: true),
                    ItemTipo = table.Column<string>(maxLength: 100, nullable: true),
                    ComposicaoCodigoComposicao = table.Column<string>(maxLength: 100, nullable: true),
                    ItemCoeficiente = table.Column<decimal>(nullable: false),
                    ItemPrecoUnitario = table.Column<decimal>(nullable: false),
                    ItemCustoTotal = table.Column<decimal>(nullable: false),
                    Prefixo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComposicoesItens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementoComposicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementoId = table.Column<int>(nullable: false),
                    ComposicaoCodigo = table.Column<string>(nullable: false),
                    Prefixo = table.Column<int>(nullable: false),
                    Dimensao = table.Column<string>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(12, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoComposicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementoInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementoId = table.Column<int>(nullable: false),
                    InsumoCodigo = table.Column<string>(nullable: false),
                    Prefixo = table.Column<string>(nullable: false),
                    Dimensao = table.Column<string>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(12, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoInsumo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementosProjeto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeProjeto = table.Column<string>(maxLength: 255, nullable: false),
                    IfcId = table.Column<string>(maxLength: 255, nullable: false),
                    NomeElementoIfc = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementosProjeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Unidade = table.Column<string>(maxLength: 10, nullable: true),
                    OrigemPreco = table.Column<string>(maxLength: 10, nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    Prefixo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => new { x.Codigo, x.Prefixo });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Composicoes");

            migrationBuilder.DropTable(
                name: "ComposicoesItens");

            migrationBuilder.DropTable(
                name: "ElementoComposicao");

            migrationBuilder.DropTable(
                name: "ElementoInsumo");

            migrationBuilder.DropTable(
                name: "ElementosProjeto");

            migrationBuilder.DropTable(
                name: "Insumos");
        }
    }
}
