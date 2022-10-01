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
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
                builder.ToTable("parcela");

                builder.HasIndex(e => e.IdContrato, "fk_parcela_contrato1_idx");

                builder.Property(e => e.DataVencimento).HasColumnType("date");

                builder.Property(e => e.NumeroParcela).HasMaxLength(45);

                builder.Property(e => e.ValorParcela).HasPrecision(10, 2);

                builder.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.ParcelasNavigation)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_parcela_contrato1");
        }
    }
}
