using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ProdutoModel> AdicionarProduto(ProdutoModel model);
        Task<ProdutoModel> AtualizarProduto(ProdutoModel model);
        Task<bool> DeletarProduto(ProdutoModel model);
        Task<ProdutoModel[]> PegarTodosProdutosAsync();
        Task<ProdutoModel> PegarProdutosPorNomeAsync(string nameSearched);


    }
}