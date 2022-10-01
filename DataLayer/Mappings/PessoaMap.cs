using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {

        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(p => p.IdPessoa);

            builder.Property(p => p.Cpf).HasMaxLength(11);

            builder.Property(p => p.NomeCompleto).HasMaxLength(255);

            builder.Property(p => p.DataNascimento).HasColumnType("Date");

            builder.Property(p => p.Email).HasMaxLength(255);

            builder
            .HasOne(x => x.Aluno)
            .WithOne(x => x.Pessoa)
            .HasForeignKey<Aluno>(b => b.IdPessoa)
            .HasConstraintName("fk_Aluno_Pessoa");
        }
    }
}
