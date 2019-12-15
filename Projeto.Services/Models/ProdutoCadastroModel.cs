using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class ProdutoCadastroModel
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Id do Fornecedor é obrigatório.")]
        public int IdFornecedor { get; set; }
    }
}
