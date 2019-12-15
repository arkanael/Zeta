using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }

        //relacionamento -> Fornecedor TEM MUITOS Produtos
        public List<Produto> Produtos { get; set; }
    }
}
