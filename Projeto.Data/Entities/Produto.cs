using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }

        //relacionamento -> Produto TEM 1 Fornecedor
        public Fornecedor Fornecedor { get; set; }
    }
}
