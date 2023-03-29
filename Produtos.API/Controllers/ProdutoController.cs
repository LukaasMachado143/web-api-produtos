using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos.Data.Context;
using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces.Services;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService) => _produtoService = produtoService;
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            // return "Neste método será recuperado todos os produtos cadastrados no BD";
            try
            {
                var produtosEncontrados = await _produtoService.PegarTodosProdutosAsync();
                if (produtosEncontrados == null){ return NoContent();}
                return Ok(produtosEncontrados);
            }
            catch (System.Exception error)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                      $"Erro ao tentar recuperar todos os Produtos. Erro:{error}"  
                                      );
            }
        }
        
        [HttpGet("{nomeProduto}")]
        public async Task<IActionResult> Get(string nomeProduto)
        {   
            //"Neste método será recuperado o produto cujo nome corresponde a pesquisa no BD";
            try
            {
                var produtoEncontrado = await _produtoService.PegarProdutosPorNomeAsync(nomeProduto);
                if (produtoEncontrado == null){ return NoContent();}
                return Ok(produtoEncontrado);
            }
            catch (System.Exception error)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                      $"Erro ao tentar recuperar o produto {nomeProduto}. Erro:{error}"  
                                      );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoModel dadosNovoProduto)
        {
            //"Neste método será inserido um novo produto no BD";
            try
            {
                var produtoAdicionado = await _produtoService.AdicionarProduto(dadosNovoProduto);
                if(produtoAdicionado == null) return StatusCode(StatusCodes.Status501NotImplemented,$"Erro ao inserir novo produto.");
                return Ok(produtoAdicionado);
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao inserir novo produto. Erro: {ex.Message}");
            }   
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProdutoModel dadosProdutoAlterado)
        {   
            //"Neste método será alterado alguma informação do produto cujo id seja correspondeente a pesquisa no BD";
            try
            {
                if(dadosProdutoAlterado.Id != id) return StatusCode(StatusCodes.Status409Conflict,"Você está tentando alterar o produto errado");
                
                var produtoAtualizado = await _produtoService.AtualizarProduto(dadosProdutoAlterado);

                if(produtoAtualizado == null) return NoContent();

                return Ok(produtoAtualizado);
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao atualizar o produto com ID: ${id}. Erro: {ex.Message}");
            }   
        }
        
        [HttpDelete("{nomeProduto}")]
        public async Task<IActionResult> Delete(string nomeProduto)
        {   
            //"Neste método será deletado o produto do BD cujo id seja correspondeente a pesquisa no BD";
            try
            {
                var produtoSelecionado = await _produtoService.PegarProdutosPorNomeAsync(nomeProduto);
                if (produtoSelecionado == null) {return NoContent();}
                if (await _produtoService.DeletarProduto(produtoSelecionado))
                {
                    return Ok(new {message = "Produto Deletado"});
                }
                else
                {
                    return BadRequest("Ocorreu algum problema não específico ao tentar deletar o produto.");
                }
            }
            catch (System.Exception error)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao deletar o produto: ${nomeProduto}. Erro: {error.Message}");
            }
        }
    }
}