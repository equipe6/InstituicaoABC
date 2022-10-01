using System;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using DataLayer.Mappings;
using DataLayer.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
                optionsBuilder.UseMySql("server=iu51mf0q32fkhfpl.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;database=e1npnncfcmgsxuw7;user=kqpfoeb5hqbt3lqp;password=yd3uv31oih2a7b5k", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ContratoMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
        }
    }
}
