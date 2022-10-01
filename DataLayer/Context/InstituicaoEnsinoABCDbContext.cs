using System;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using DataLayer.Mappings;
using DataLayer.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

#nullable disable

namespace DataLayer.Context
{
    public partial class InstituicaoEnsinoABCDbContext : DbContext
    {
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Documento> Documentos{ get; set; }
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<Pagamento> Pagamentos { get; set; }
        public virtual DbSet<Parcela> Parcelas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=sqlitedemo.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ContratoMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
        }
    }
}
