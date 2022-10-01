using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.IdPessoa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Login = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlagAdmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Login = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlagAdmin = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: true),
                    PessoaNavigationIdPessoa = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Parcelas = table.Column<int>(type: "int", nullable: true),
                    DiaPagamento = table.Column<int>(type: "int", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: true),
                    ValorPago = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Status = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdAluno = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    NomeDocumento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MimeType = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Arquivo = table.Column<string>(type: "longtext", maxLength: 20000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroParcela = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorParcela = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    IdContratoNavigationId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: true),
                    ValorPago = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    FormaPagamento = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdParcela = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "Email", "FlagAdmin", "Login", "Senha" },
                values: new object[] { new Guid("b4378115-5f67-4b3b-b42e-46c0613821bb"), "emersonabeier@hotmail.com", 1, "18521844000", "7C4A8D09CA3762AF61E59520943DC26494F8941B" });

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
