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
    public class DocumentoMap : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {

            builder.ToTable("documento");

            builder.HasKey(e => e.IdDocumento);
            
            builder.Property(e => e.Arquivo).HasMaxLength(20000);

            builder.Property(e => e.Descricao).HasMaxLength(255);

            builder.Property(e => e.NomeDocumento).HasMaxLength(255);

            builder.Property(e => e.MimeType).HasMaxLength(45);
        }
    }
}
