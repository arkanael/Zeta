using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post
            (FornecedorCadastroModel model, 
            [FromServices] IFornecedorRepository repository, 
            [FromServices] IMapper mapper)
        {
            //verificar se os campos da model não passaram nas validações
            if ( ! ModelState.IsValid)
                return BadRequest("Ocorreram erros de validação.");

            try
            {
                var fornecedor = mapper.Map<Fornecedor>(model);
                repository.Inserir(fornecedor);

                return Ok("Fornecedor cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(
            FornecedorEdicaoModel model,
            [FromServices] IFornecedorRepository repository,
            [FromServices] IMapper mapper)
        {
            //verificar se os campos da model não passaram nas validações
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erros de validação.");

            try
            {
                var fornecedor = mapper.Map<Fornecedor>(model);
                repository.Alterar(fornecedor);

                return Ok("Fornecedor atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id, [FromServices] IFornecedorRepository repository)
        {
            try
            {
                repository.Excluir(id);
                return Ok("Fornecedor excluído com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IFornecedorRepository repository,
            [FromServices] IMapper mapper
            )
        {
            try
            {
                var result = mapper.Map<List<FornecedorConsultaModel>>(repository.ObterTodos());
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            int id, 
            [FromServices] IFornecedorRepository repository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                var result = mapper.Map<FornecedorConsultaModel>(repository.ObterPorId(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}