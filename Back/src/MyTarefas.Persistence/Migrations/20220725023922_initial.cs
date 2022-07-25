using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyTarefas.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Titulo = table.Column<string>(type: "text", nullable: true),
                    Projeto = table.Column<string>(type: "text", nullable: true),
                    posicaoVertical = table.Column<int>(type: "integer", nullable: false),
                    DataPrevisao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TarefaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acompanhamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HorasPrevistas = table.Column<string>(type: "text", nullable: true),
                    Saldo = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompanhamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acompanhamentos_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    CardId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcompanhamentoUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    AcompanhamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanhamentoUsuario", x => new { x.AcompanhamentoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_AcompanhamentoUsuario_Acompanhamentos_AcompanhamentoId",
                        column: x => x.AcompanhamentoId,
                        principalTable: "Acompanhamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompanhamentoUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 318788161L, "Finalizado" },
                    { 639860993L, "Aguardando" },
                    { 1139418042L, "Em Andamento" },
                    { 1769495653L, "Outros" },
                    { 2129261870L, "Pendência" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 264459367L, "Carlos" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Projeto", "TarefaId", "Titulo", "posicaoVertical" },
                values: new object[,]
                {
                    { 455870484L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colunas utilizadas: Código, nome, Descrição...", "Company", 1769495653L, "Listagem de clientes", 2 },
                    { 668031498L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaaaaaaa", "Company", 639860993L, "testee", 1 },
                    { 710789295L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull, após isso...", "Company", 639860993L, "Criar Migration", 0 },
                    { 990342459L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbbbbbbbbbbbbb", "Company", 639860993L, "bbbbbbbbbb", 2 },
                    { 1892751283L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ccccccccccccc", "Company", 639860993L, "cccccccccc", 3 }
                });

            migrationBuilder.InsertData(
                table: "Acompanhamentos",
                columns: new[] { "Id", "CardId", "HorasPrevistas", "Saldo", "Status" },
                values: new object[,]
                {
                    { 521638193L, 455870484L, "00:30", "00:10", 1 },
                    { 1200252569L, 710789295L, "00:30", "00:10", 1 }
                });

            migrationBuilder.InsertData(
                table: "AcompanhamentoUsuario",
                columns: new[] { "AcompanhamentoId", "UsuarioId" },
                values: new object[] { 1200252569L, 264459367L });

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_CardId",
                table: "Acompanhamentos",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcompanhamentoUsuario_UsuarioId",
                table: "AcompanhamentoUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TarefaId",
                table: "Cards",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_CardId",
                table: "Departamentos",
                column: "CardId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompanhamentoUsuario");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Acompanhamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
