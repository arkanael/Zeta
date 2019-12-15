using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Services.Models
{
    public class FornecedorCadastroModel
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
    }
}
