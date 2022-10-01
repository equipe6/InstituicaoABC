﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    FlagAdmin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    IdPessoa = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Aluno_Pessoa",
                        column: x => x.IdPessoa,
                        principalTable: "pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FlagAdmin = table.Column<ulong>(type: "INTEGER", nullable: false),
                    IdPessoa = table.Column<int>(type: "INTEGER", nullable: true),
                    PessoaNavigationIdPessoa = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_pessoa_PessoaNavigationIdPessoa",
                        column: x => x.PessoaNavigationIdPessoa,
                        principalTable: "pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ValorTotal = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Parcelas = table.Column<int>(type: "INTEGER", nullable: true),
                    DiaPagamento = table.Column<int>(type: "INTEGER", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: true),
                    ValorPago = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    IdAluno = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato", x => x.Id);
                    table.ForeignKey(
                        name: "fk_contrato_aluno1",
                        column: x => x.IdAluno,
                        principalTable: "aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAluno = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeDocumento = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    Arquivo = table.Column<string>(type: "TEXT", maxLength: 20000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => x.IdDocumento);
                    table.ForeignKey(
                        name: "fk_documento_aluno1",
                        column: x => x.IdAluno,
                        principalTable: "aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroParcela = table.Column<string>(type: "TEXT", nullable: true),
                    ValorParcela = table.Column<decimal>(type: "TEXT", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdContrato = table.Column<int>(type: "INTEGER", nullable: false),
                    IdContratoNavigationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_contrato_IdContratoNavigationId",
                        column: x => x.IdContratoNavigationId,
                        principalTable: "contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: true),
                    ValorPago = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    FormaPagamento = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    IdAluno = table.Column<int>(type: "INTEGER", nullable: false),
                    IdParcela = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "fk_pagamento_aluno1",
                        column: x => x.IdAluno,
                        principalTable: "aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pagamento_parcela1",
                        column: x => x.IdParcela,
                        principalTable: "Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "Email", "FlagAdmin", "Login", "Senha" },
                values: new object[] { new Guid("9f688f12-a9e9-4601-b7f7-e49312e60ced"), "emersonabeier@hotmail.com", 1, "18521844000", "7C4A8D09CA3762AF61E59520943DC26494F8941B" });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_IdPessoa",
                table: "aluno",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MatriculaUniqu",
                table: "aluno",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_contrato_aluno1_idx",
                table: "contrato",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_documento_IdAluno",
                table: "documento",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "fk_pagamento_aluno1_idx",
                table: "pagamento",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "fk_pagamento_parcela1_idx",
                table: "pagamento",
                column: "IdParcela");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_IdContratoNavigationId",
                table: "Parcelas",
                column: "IdContratoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaNavigationIdPessoa",
                table: "Usuarios",
                column: "PessoaNavigationIdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "contrato");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
