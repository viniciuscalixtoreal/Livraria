﻿using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infrastructure.EntitiesConfiguration
{
    public class LivrariaConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Titulo).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Autor).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Lancamento).IsRequired();
            builder.Property(p => p.Capa).HasMaxLength(200);
        }
    }
}
