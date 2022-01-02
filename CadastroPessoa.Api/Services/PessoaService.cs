using CadastroPessoa.Api.Models;
using CadastroPessoa.Api.Repository.Interfaces;
using CadastroPessoa.Api.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.Api.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository repository;

        public PessoaService(IPessoaRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
        {
            return await repository.CriarPessoa(pessoa);
        }
        public async Task<List<Pessoa>> BuscarPorTodos(string nome, int idade, string sexo, string signo)
        {
            return await repository.BuscarPorTodos(nome, idade, sexo, signo);
        }
        //public List<Pessoa> BuscarPorNome(string nome)
        //{
        //    return this.repository.BuscarPorNome(nome);
        //}
        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await this.repository.BuscarPorId(id);
        }
        public async Task DeletarPorId(int id)
        {
            await repository.DeletarPorId(id);
        }
        public async Task AtualizarPessoaPorId(Pessoa pessoa)
        {
            await repository.AtualizarPessoaPorId(pessoa);
        }
    }
}