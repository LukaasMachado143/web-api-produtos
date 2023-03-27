using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Entities;
using Produtos.Data.Mapping;

namespace Produtos.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("Produtos");
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Property(x => x.QuantityStock).HasDefaultValue(0);
        }

        
        
    }
}