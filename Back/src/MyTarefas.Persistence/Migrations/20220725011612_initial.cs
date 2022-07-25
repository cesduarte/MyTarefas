﻿using System;
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
                    { 93663805L, "Finalizado" },
                    { 125802249L, "Pendência" },
                    { 336490917L, "Em Andamento" },
                    { 1095109455L, "Outros" },
                    { 1712405553L, "Aguardando" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1855701605L, "Carlos" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Projeto", "TarefaId", "Titulo", "posicaoVertical" },
                values: new object[,]
                {
                    { 416741983L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaaaaaaaa", "Company", 1712405553L, "testee", 1 },
                    { 499607459L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ccccccccccccc", "Company", 1712405553L, "cccccccccc", 4 },
                    { 878851122L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull, após isso...", "Company", 1712405553L, "Criar Migration", 0 },
                    { 1158010731L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbbbbbbbbbbbbb", "Company", 1712405553L, "bbbbbbbbbb", 2 },
                    { 1534802998L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colunas utilizadas: Código, nome, Descrição...", "Company", 1095109455L, "Listagem de clientes", 2 }
                });

            migrationBuilder.InsertData(
                table: "Acompanhamentos",
                columns: new[] { "Id", "CardId", "HorasPrevistas", "Saldo", "Status" },
                values: new object[,]
                {
                    { 1911213533L, 1534802998L, "00:30", "00:10", 1 },
                    { 2080741784L, 878851122L, "00:30", "00:10", 1 }
                });

            migrationBuilder.InsertData(
                table: "AcompanhamentoUsuario",
                columns: new[] { "AcompanhamentoId", "UsuarioId" },
                values: new object[] { 2080741784L, 1855701605L });

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
