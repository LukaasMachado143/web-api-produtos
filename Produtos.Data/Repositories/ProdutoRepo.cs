using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produtos.Data.Context;
using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces.Repositories;

namespace Produtos.Data.Repositories
{
    public class ProdutoRepo : GeneralRepo, IProdutoRepo
    {
        public DataContext _context;
        public ProdutoRepo(DataContext context) : base(context){_context = context;}
            
        public async Task<ProdutoModel> PegarProdutoPorId(int id)
        {
            IQueryable<ProdutoModel> query = _context.Products;
            query = query.AsNoTracking().OrderBy(prod => prod.Id);
            return await query.FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public async Task<ProdutoModel> PegarProdutoPorNome(string name)
        {
            IQueryable<ProdutoModel> query = _context.Products;
            query = query.AsNoTracking().OrderBy(prod => prod.Name);
            return await query.FirstOrDefaultAsync(prod => prod.Name == name);
        }

        public async Task<ProdutoModel[]> PegarTodosProdutos()
        {
            IQueryable<ProdutoModel> query = _context.Products;
            query = query.AsNoTracking().OrderBy(prod => prod.Name);
            return await query.ToArrayAsync();
        }
    }
}