using DataLayer.Models;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappings
{
    public class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("contrato");

            builder.HasIndex(e => e.IdAluno, "fk_contrato_aluno1_idx");

            builder.Property(e => e.DataInicio).HasColumnType("date");

            builder.Property(e => e.Descricao).HasMaxLength(255);

            builder.Property(e => e.Status).HasMaxLength(45);

            builder.Property(e => e.ValorPago).HasPrecision(10, 2);

            builder.Property(e => e.ValorTotal).HasPrecision(10, 2);

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contrato_aluno1");
        }
    }
}
