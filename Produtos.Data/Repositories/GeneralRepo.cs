using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Data.Context;
using Produtos.Domain.Interfaces.Repositories;

namespace Produtos.Data.Repositories
{
    public class GeneralRepo : IGeneralRepo
    {
        private readonly DataContext _context;
        public GeneralRepo(DataContext context) => _context = context;


        public void Adicionar<T>(T entity) where T : class => _context.Add(entity);
        public void Atualizar<T>(T entity) where T : class => _context.Update(entity);
        public void Deletar<T>(T entity) where T : class => _context.Remove(entity);
        public async Task<bool> SalvarMudancasAsync() => (await _context.SaveChangesAsync()) > 0;
    }
}