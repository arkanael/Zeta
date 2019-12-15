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
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post
           (ProdutoCadastroModel model,
           [FromServices] IProdutoRepository repository,
           [FromServices] IMapper mapper)
        {
            //verificar se os campos da model não passaram nas validações
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erros de validação.");

            try
            {
                var produto = mapper.Map<Produto>(model);
                repository.Inserir(produto);

                return Ok("Produto cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(
            ProdutoEdicaoModel model,
            [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper)
        {
            //verificar se os campos da model não passaram nas validações
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erros de validação.");

            try
            {
                var produto = mapper.Map<Produto>(model);
                repository.Alterar(produto);

                return Ok("Produto atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id, [FromServices] IProdutoRepository repository)
        {
            try
            {
                repository.Excluir(id);
                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper
            )
        {
            try
            {
                var result = mapper.Map<List<ProdutoConsultaModel>>(repository.ObterTodos());
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            int id,
            [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var result = mapper.Map<ProdutoConsultaModel>(repository.ObterPorId(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}