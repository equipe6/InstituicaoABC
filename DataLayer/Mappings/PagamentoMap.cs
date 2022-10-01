using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Mappings
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {

            builder.ToTable("pagamento");

            builder.HasIndex(e => e.IdAluno, "fk_pagamento_aluno1_idx");

            builder.HasIndex(e => e.IdParcela, "fk_pagamento_parcela1_idx");

            builder.Property(e => e.DataPagamento).HasColumnType("date");

            builder.Property(e => e.FormaPagamento).HasMaxLength(45);

            builder.Property(e => e.ValorPago).HasPrecision(10, 2);

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pagamento_aluno1");

            builder.HasOne(d => d.IdParcelaNavigation)
                .WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdParcela)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pagamento_parcela1");

        }
    }
}
