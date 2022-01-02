using CadastroPessoa.Api.Models;
using CadastroPessoa.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CadastroPessoa.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService service;
        public PessoasController(IPessoaService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string nome, [FromQuery] int idade, [FromQuery] string sexo, [FromQuery] string signo)
        {
            try
            {
                var result = await this.service.BuscarPorTodos(nome, idade, sexo, signo);
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa pessoa)
        {
            try
            {
                var nome = pessoa.Nome;
                var idade = pessoa.Idade;
                var sexo = pessoa.Sexo;
                var signo = pessoa.Signo;

                await service.CriarPessoa(pessoa);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,[FromBody] Pessoa pessoa)
        {
            try
            {
                pessoa.Id = id;
                await service.AtualizarPessoaPorId(pessoa);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await service.DeletarPorId(id);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
