using Microsoft.EntityFrameworkCore.Migrations;

namespace OrcamentosIfc.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "ElementoComposicaoAnalitica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementoId = table.Column<int>(nullable: false),
                    ComposicaoAnaliticaId = table.Column<int>(nullable: false),
                    Dimensao = table.Column<string>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(12, 6)", nullable: false),
                    ElementoProjetoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoComposicaoAnalitica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementoComposicaoAnalitica_ComposicoesAnaliticas_ComposicaoAnaliticaId",
                        column: x => x.ComposicaoAnaliticaId,
                        principalTable: "ComposicoesAnaliticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementoComposicaoAnalitica_ElementosProjeto_ElementoProjetoId",
                        column: x => x.ElementoProjetoId,
                        principalTable: "ElementosProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementoComposicaoSintetica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementoId = table.Column<int>(nullable: false),
                    ComposicaoSinteticaId = table.Column<int>(nullable: false),
                    Dimensao = table.Column<string>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(12, 6)", nullable: false),
                    ElementoProjetoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoComposicaoSintetica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementoComposicaoSintetica_ComposicoesSinteticas_ComposicaoSinteticaId",
                        column: x => x.ComposicaoSinteticaId,
                        principalTable: "ComposicoesSinteticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementoComposicaoSintetica_ElementosProjeto_ElementoProjetoId",
                        column: x => x.ElementoProjetoId,
                        principalTable: "ElementosProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementoInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementoId = table.Column<int>(nullable: false),
                    InsumoId = table.Column<int>(nullable: false),
                    Dimensao = table.Column<string>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(12, 6)", nullable: false),
                    ElementoProjetoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoInsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementoInsumo_ElementosProjeto_ElementoProjetoId",
                        column: x => x.ElementoProjetoId,
                        principalTable: "ElementosProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementoInsumo_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementoComposicaoAnalitica_ComposicaoAnaliticaId",
                table: "ElementoComposicaoAnalitica",
                column: "ComposicaoAnaliticaId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoComposicaoAnalitica_ElementoProjetoId",
                table: "ElementoComposicaoAnalitica",
                column: "ElementoProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoComposicaoSintetica_ComposicaoSinteticaId",
                table: "ElementoComposicaoSintetica",
                column: "ComposicaoSinteticaId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoComposicaoSintetica_ElementoProjetoId",
                table: "ElementoComposicaoSintetica",
                column: "ElementoProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoInsumo_ElementoProjetoId",
                table: "ElementoInsumo",
                column: "ElementoProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoInsumo_InsumoId",
                table: "ElementoInsumo",
                column: "InsumoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementoComposicaoAnalitica");

            migrationBuilder.DropTable(
                name: "ElementoComposicaoSintetica");

            migrationBuilder.DropTable(
                name: "ElementoInsumo");

            migrationBuilder.DropTable(
                name: "ComposicoesAnaliticas");

            migrationBuilder.DropTable(
                name: "ComposicoesSinteticas");

            migrationBuilder.DropTable(
                name: "ElementosProjeto");

            migrationBuilder.DropTable(
                name: "Insumos");
        }
    }
}
