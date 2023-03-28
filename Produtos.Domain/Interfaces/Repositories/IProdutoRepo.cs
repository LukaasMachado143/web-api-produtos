using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Interfaces.Repositories
{
    public interface IProdutoRepo : IGeneralRepo
    {
        Task<ProdutoModel[]> PegarTodosProdutos();
        Task<ProdutoModel> PegarProdutoPorNome(string name);
        Task<ProdutoModel> PegarProdutoPorId(int id);

    }
}