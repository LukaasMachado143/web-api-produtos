using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produtos.Data.Mapping;
using Produtos.Domain.Entities;

namespace Produtos.Data.Context
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}
        public DbSet<ProdutoModel>? Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new ProdutoMap());
    }

    
}