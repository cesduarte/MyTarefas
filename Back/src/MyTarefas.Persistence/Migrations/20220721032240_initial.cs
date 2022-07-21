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
                name: "AcompanhamentoUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    AcompanhamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanhamentoUsuario", x => new { x.AcompanhamentoId, x.UsuarioId });
                });

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
                name: "AcompanhamentoUsuarioUsuario",
                columns: table => new
                {
                    UsuariosId = table.Column<long>(type: "bigint", nullable: false),
                    AcompanhamentosUsuariosAcompanhamentoId = table.Column<long>(type: "bigint", nullable: false),
                    AcompanhamentosUsuariosUsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanhamentoUsuarioUsuario", x => new { x.UsuariosId, x.AcompanhamentosUsuariosAcompanhamentoId, x.AcompanhamentosUsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_AcompanhamentoUsuarioUsuario_AcompanhamentoUsuario_Acompanh~",
                        columns: x => new { x.AcompanhamentosUsuariosAcompanhamentoId, x.AcompanhamentosUsuariosUsuarioId },
                        principalTable: "AcompanhamentoUsuario",
                        principalColumns: new[] { "AcompanhamentoId", "UsuarioId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompanhamentoUsuarioUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
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
                name: "AcompanhamentoAcompanhamentoUsuario",
                columns: table => new
                {
                    AcompanhamentosId = table.Column<long>(type: "bigint", nullable: false),
                    AcompanhamentosUsuariosAcompanhamentoId = table.Column<long>(type: "bigint", nullable: false),
                    AcompanhamentosUsuariosUsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanhamentoAcompanhamentoUsuario", x => new { x.AcompanhamentosId, x.AcompanhamentosUsuariosAcompanhamentoId, x.AcompanhamentosUsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_AcompanhamentoAcompanhamentoUsuario_Acompanhamentos_Acompan~",
                        column: x => x.AcompanhamentosId,
                        principalTable: "Acompanhamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompanhamentoAcompanhamentoUsuario_AcompanhamentoUsuario_A~",
                        columns: x => new { x.AcompanhamentosUsuariosAcompanhamentoId, x.AcompanhamentosUsuariosUsuarioId },
                        principalTable: "AcompanhamentoUsuario",
                        principalColumns: new[] { "AcompanhamentoId", "UsuarioId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcompanhamentoUsuario",
                columns: new[] { "AcompanhamentoId", "UsuarioId" },
                values: new object[] { 1267064512L, 2016575754L });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 512228209L, "Aguardando" },
                    { 1448567844L, "Em Andamento" },
                    { 1549758251L, "Finalizado" },
                    { 1646670742L, "Pendência" },
                    { 1829130858L, "Outros" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2016575754L, "Carlos" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Projeto", "TarefaId", "Titulo" },
                values: new object[] { 4669612L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull, após isso...", "Company", 1448567844L, "Criar Migration" });

            migrationBuilder.InsertData(
                table: "Acompanhamentos",
                columns: new[] { "Id", "CardId", "HorasPrevistas", "Saldo", "Status" },
                values: new object[] { 1267064512L, 4669612L, "00:30", "00:10", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AcompanhamentoAcompanhamentoUsuario_AcompanhamentosUsuarios~",
                table: "AcompanhamentoAcompanhamentoUsuario",
                columns: new[] { "AcompanhamentosUsuariosAcompanhamentoId", "AcompanhamentosUsuariosUsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_CardId",
                table: "Acompanhamentos",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcompanhamentoUsuarioUsuario_AcompanhamentosUsuariosAcompan~",
                table: "AcompanhamentoUsuarioUsuario",
                columns: new[] { "AcompanhamentosUsuariosAcompanhamentoId", "AcompanhamentosUsuariosUsuarioId" });

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
                name: "AcompanhamentoAcompanhamentoUsuario");

            migrationBuilder.DropTable(
                name: "AcompanhamentoUsuarioUsuario");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Acompanhamentos");

            migrationBuilder.DropTable(
                name: "AcompanhamentoUsuario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
