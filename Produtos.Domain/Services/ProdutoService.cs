using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Interfaces.Services;

namespace Produtos.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepo _produtoRepo;

        public ProdutoService(IProdutoRepo produtoRepo) => _produtoRepo = produtoRepo;
        public async Task<ProdutoModel> AdicionarProduto(ProdutoModel model)
        {
            if (await _produtoRepo.PegarProdutoPorNome(model.Name) != null)
            {
                throw new Exception("Produto Existente, favor alterar a quantidade em estoque");
            }
            else if (await _produtoRepo.PegarProdutoPorId(model.Id) == null)
            {
                _produtoRepo.Adicionar(model);
                if (await _produtoRepo.SalvarMudancasAsync())
                {
                    return model;
                }
            }
            return null;
        }

        public async Task<ProdutoModel> AtualizarProduto(ProdutoModel model)
        {
            if (await _produtoRepo.PegarProdutoPorNome(model.Name) != null)
            {
                _produtoRepo.Atualizar(model);
                if (await _produtoRepo.SalvarMudancasAsync())
                {
                    return model;
                }
                
            }
            else
            {
                throw new Exception("Produto Inexistente, favor adicioná-lo");
            }
            
            return null;
        }

        public async Task<bool> DeletarProduto(ProdutoModel model)
        {
            if (await _produtoRepo.PegarProdutoPorId(model.Id) != null)
            {
                _produtoRepo.Deletar(model);
                return await _produtoRepo.SalvarMudancasAsync();
                
            }
            else
            {
                throw new Exception("Produto Inexistente, favor adicioná-lo antes de deletá-lo");
            }
        }

        public async Task<ProdutoModel>? PegarProdutosPorNomeAsync(string nameSearched)
        {
            try
            {
                var produtoEncontrado = await _produtoRepo.PegarProdutoPorNome(nameSearched);
                if (produtoEncontrado == null){return null;}
                return produtoEncontrado;
            }
            catch (System.Exception e)
            {
                
                throw new Exception(e.Message);
            }
           
        }

        public Task<ProdutoModel[]>? PegarTodosProdutosAsync()
        {
            try
            {
                var produtos = _produtoRepo.PegarTodosProdutos();
                if (produtos == null){return null;}
                return produtos;
            }
            catch (System.Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}