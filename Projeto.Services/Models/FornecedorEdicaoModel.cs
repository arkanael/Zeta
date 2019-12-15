using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class FornecedorEdicaoModel
    {
        [Required(ErrorMessage = "Id do Fornecedor é obrigatório.")]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
    }
}
