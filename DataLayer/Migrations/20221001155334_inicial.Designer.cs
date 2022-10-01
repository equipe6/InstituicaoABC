﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(InstituicaoEnsinoABCDbContext))]
    [Migration("20221001155334_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("DataLayer.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Matricula");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.HasIndex(new[] { "Matricula" }, "MatriculaUniqu")
                        .IsUnique();

                    b.ToTable("aluno");
                });

            modelBuilder.Entity("DataLayer.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("DiaPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.Property<int?>("Parcelas")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<decimal?>("ValorPago")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("ValorTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdAluno" }, "fk_contrato_aluno1_idx");

                    b.ToTable("contrato");
                });

            modelBuilder.Entity("DataLayer.Models.Documento", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Arquivo")
                        .HasMaxLength(20000)
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.Property<string>("MimeType")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("NomeDocumento")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdDocumento");

                    b.HasIndex("IdAluno");

                    b.ToTable("documento");
                });

            modelBuilder.Entity("DataLayer.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("date");

                    b.Property<string>("FormaPagamento")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.Property<int>("IdParcela")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorPago")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdAluno" }, "fk_pagamento_aluno1_idx");

                    b.HasIndex(new[] { "IdParcela" }, "fk_pagamento_parcela1_idx");

                    b.ToTable("pagamento");
                });

            modelBuilder.Entity("DataLayer.Models.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdContrato")
                        .HasColumnType("int");

                    b.Property<int?>("IdContratoNavigationId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroParcela")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("ValorParcela")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("IdContratoNavigationId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("DataLayer.Models.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdPessoa");

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("DataLayer.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<ulong>("FlagAdmin")
                        .HasColumnType("bigint unsigned");

                    b.Property<int?>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.Property<int?>("PessoaNavigationIdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PessoaNavigationIdPessoa");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("FlagAdmin")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("usuario");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b4378115-5f67-4b3b-b42e-46c0613821bb"),
                            Email = "emersonabeier@hotmail.com",
                            FlagAdmin = 1,
                            Login = "18521844000",
                            Senha = "7C4A8D09CA3762AF61E59520943DC26494F8941B"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Aluno", b =>
                {
                    b.HasOne("DataLayer.Models.Pessoa", "Pessoa")
                        .WithOne("Aluno")
                        .HasForeignKey("DataLayer.Models.Aluno", "IdPessoa")
                        .HasConstraintName("fk_Aluno_Pessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("DataLayer.Models.Contrato", b =>
                {
                    b.HasOne("DataLayer.Models.Aluno", "IdAlunoNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("fk_contrato_aluno1")
                        .IsRequired();

                    b.Navigation("IdAlunoNavigation");
                });

            modelBuilder.Entity("DataLayer.Models.Documento", b =>
                {
                    b.HasOne("DataLayer.Models.Aluno", "Aluno")
                        .WithMany("Documentos")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("fk_documento_aluno1")
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("DataLayer.Models.Pagamento", b =>
                {
                    b.HasOne("DataLayer.Models.Aluno", "IdAlunoNavigation")
                        .WithMany("Pagamentos")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("fk_pagamento_aluno1")
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Parcela", "IdParcelaNavigation")
                        .WithMany("Pagamentos")
                        .HasForeignKey("IdParcela")
                        .HasConstraintName("fk_pagamento_parcela1")
                        .IsRequired();

                    b.Navigation("IdAlunoNavigation");

                    b.Navigation("IdParcelaNavigation");
                });

            modelBuilder.Entity("DataLayer.Models.Parcela", b =>
                {
                    b.HasOne("DataLayer.Models.Contrato", "IdContratoNavigation")
                        .WithMany("ParcelasNavigation")
                        .HasForeignKey("IdContratoNavigationId");

                    b.Navigation("IdContratoNavigation");
                });

            modelBuilder.Entity("DataLayer.Models.Usuario", b =>
                {
                    b.HasOne("DataLayer.Models.Pessoa", "PessoaNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("PessoaNavigationIdPessoa");

                    b.Navigation("PessoaNavigation");
                });

            modelBuilder.Entity("DataLayer.Models.Aluno", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Documentos");

                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("DataLayer.Models.Contrato", b =>
                {
                    b.Navigation("ParcelasNavigation");
                });

            modelBuilder.Entity("DataLayer.Models.Parcela", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("DataLayer.Models.Pessoa", b =>
                {
                    b.Navigation("Aluno");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}