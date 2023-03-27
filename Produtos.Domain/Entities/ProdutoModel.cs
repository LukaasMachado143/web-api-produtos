using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Domain.Entities
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int QuantityStock { get; set; }

        public ProdutoModel(int id, string name, string brand, int quantityStock)
        {
            this.Id = id;
            this.Name = name;
            this.Brand = brand;
            this.QuantityStock = quantityStock;
        }
    }


}