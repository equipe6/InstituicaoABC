using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Login).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Senha).IsRequired();

            builder.HasData(new Usuario
            {
                Id = Guid.NewGuid(),
                Email = "emersonabeier@hotmail.com",
                FlagAdmin = 1,
                Login = "18521844000",
                Senha = "7C4A8D09CA3762AF61E59520943DC26494F8941B"
            });
        }
    }
}
