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
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {

            builder
                .ToTable("aluno");

            builder
                .HasIndex(e => e.Matricula, "MatriculaUniqu")
                .IsUnique();

            builder
                .Property(e => e.Matricula)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnName("Matricula");


            builder.HasMany(a => a.Documentos)
                .WithOne(p => p.Aluno)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_documento_aluno1");
        }
    }
}
