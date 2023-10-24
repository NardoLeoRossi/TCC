using Microsoft.EntityFrameworkCore.Migrations;

namespace OrcamentosIfc.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComposicoesAnaliticas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoClasse = table.Column<string>(maxLength: 100, nullable: true),
                    SiglaClasse = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoTipo1 = table.Column<string>(maxLength: 100, nullable: true),
                    SiglaTipo1 = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoAgrupador = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoAgrupador = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoComposicao = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoComposicao = table.Column<string>(maxLength: 1000, nullable: true),
                    Unidade = table.Column<string>(maxLength: 10, nullable: true),
                    OrigemPreco = table.Column<string>(maxLength: 100, nullable: true),
                    CustoTotal = table.Column<decimal>(nullable: false),
                    ItemTipo = table.Column<string>(maxLength: 100, nullable: true),
                    ItemCodigo = table.Column<string>(maxLength: 100, nullable: true),
                    ItemDescricao = table.Column<string>(maxLength: 1000, nullable: true),
                    ItemUnidade = table.Column<string>(maxLength: 10, nullable: true),
                    ItemOrigemPreco = table.Column<string>(maxLength: 100, nullable: true),
                    ItemCoeficiente = table.Column<decimal>(nullable: false),
                    ItemPrecoUnitario = table.Column<decimal>(nullable: false),
                    ItemCustoTotal = table.Column<decimal>(nullable: false),
                    Vinculo = table.Column<string>(maxLength: 100, nullable: true),
                    Prefixo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComposicoesAnaliticas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComposicoesSinteticas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoClasse = table.Column<string>(maxLength: 100, nullable: true),
                    SiglaClasse = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoTipo1 = table.Column<string>(maxLength: 100, nullable: true),
                    SiglaTipo1 = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoAgrupador = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoAgrupador = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoComposicao = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoComposicao = table.Column<string>(maxLength: 1000, nullable: true),
                    Unidade = table.Column<string>(maxLength: 10, nullable: true),
                    OrigemPreco = table.Column<string>(maxLength: 100, nullable: true),
                    CustoTotal = table.Column<decimal>(nullable: false),
                    Vinculo = table.Column<string>(maxLength: 100, nullable: true),
                    Prefixo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComposicoesSinteticas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(maxLength: 10, nullable: true),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Unidade = table.Column<string>(maxLength: 10, nullable: true),
                    OrigemPreco = table.Column<string>(maxLength: 10, nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    Prefixo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComposicoesAnaliticas");

            migrationBuilder.DropTable(
                name: "ComposicoesSinteticas");

            migrationBuilder.DropTable(
                name: "Insumos");
        }
    }
}
