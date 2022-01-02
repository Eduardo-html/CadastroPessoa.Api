using CadastroPessoa.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.Api.Repository.Interfaces
{
    public interface IPessoaRepository
    {

        public Task<Pessoa> CriarPessoa(Pessoa pessoa);
        public Task<List<Pessoa>> BuscarPorTodos(string nome, int idade, string sexo, string signo);
        public Task<Pessoa> BuscarPorId(int id);
        //public List<Pessoa> BuscarPorNome(string nome);
        public Task AtualizarPessoaPorId(Pessoa pessoa);
        public Task DeletarPorId(int id);
    }
}