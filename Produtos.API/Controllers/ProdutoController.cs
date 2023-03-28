using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos.Data.Context;
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
        public string Get()
        {   
            return "Neste método será recuperado todos os produtos cadastrados no BD";
           
        }
        
        [HttpGet("{nomeProduto}")]
        public string Get(string nomeProduto)
        {   
            return "Neste método será recuperado o produto cujo nome corresponde a pesquisa no BD";
        }

        [HttpPost]
        public string Post()
        {
            return "Neste método será inserido um novo produto no BD";

        }

        [HttpPut("{id}")]
        public string Put(int id)
        {   
            return "Neste método será alterado alguma informação do produto cujo id seja correspondeente a pesquisa no BD";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {   
            return "Neste método será deletado o produto do BD cujo id seja correspondeente a pesquisa no BD";
        }
    }
}