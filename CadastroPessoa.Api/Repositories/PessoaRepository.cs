using CadastroPessoa.Api.Models;
using CadastroPessoa.Api.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Api.Repositories
{
    public class A : B {}
    public class B { }
    
    public class PessoaRepository : IPessoaRepository
    {
        private static List<Pessoa> pessoas { get; set; } = new List<Pessoa>();
            
                public async Task<List<Pessoa>> BuscarPorTodos(string nome, int idade, string sexo, string signo)
                {
                    var listaPessoa = new List<Pessoa>();
                    using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=Cadastro; Integrated Security=true"))
                    {
                        var pessoaResult = await connection.QueryAsync<Pessoa>("SELECT * FROM  dbo.Pessoa WHERE (@nome is null or nome = @nome) AND (@idade = 0 or idade = @idade) AND (@sexo is null or sexo = @sexo) AND (@signo is null or signo = @signo)", new { nome, idade,sexo, signo});
                        listaPessoa = pessoaResult.ToList();
                    }
                    return listaPessoa;
                }
        public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=Cadastro; Integrated Security=true"))
            {
                var listaPessoa = new List<Pessoa>();
                var resultado = await connection.QueryAsync<Pessoa>(@"INSERT INTO Pessoa (Nome, Idade, Sexo, Signo)VALUES(@nome, @idade, @sexo, @signo)", new { nome = pessoa.Nome, idade = pessoa.Idade, sexo = pessoa.Sexo, signo = pessoa.Signo.ToString()});

                listaPessoa = resultado.ToList();
            }
            return pessoa;
        }
        public async Task<Pessoa> BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=Cadastro; Integrated Security=true"))
            {
                return await connection.QueryFirstOrDefaultAsync<Pessoa>("SELECT * FROM dbo.Pessoa WHERE Id = @id", new { id});
            }
        }
        //public List<Pessoa> BuscarPorNome(string nome)
        //{
        //    return pessoas.Where(x => x.Nome == nome).ToList();
        //}

        public async Task AtualizarPessoaPorId(Pessoa pessoa)
        {
            var pessoaEntity = await this.BuscarPorId(pessoa.Id);

            if (!string.IsNullOrEmpty(pessoa.Nome))
                pessoaEntity.Nome = pessoa.Nome;
            if (!string.IsNullOrEmpty(pessoa.Sexo))
                pessoaEntity.Sexo = pessoa.Sexo;
            if (pessoa.Idade != 0)
                pessoaEntity.Idade = pessoa.Idade;
            if (pessoa.Signo.HasValue)
                pessoaEntity.Signo = pessoa.Signo;
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=Cadastro; Integrated Security=true"))
            {
                var listaPessoa = new List<Pessoa>();
                var resultado = await connection.ExecuteAsync(@"UPDATE Pessoa SET Nome = @nome , Idade = @idade, Sexo = @sexo, Signo = @signo WHERE Id = @id", new { id = pessoaEntity.Id, nome = pessoaEntity.Nome, idade = pessoaEntity.Idade, sexo = pessoaEntity.Sexo, signo = pessoaEntity.Signo.ToString() });
            }
        }
        public async Task DeletarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=Cadastro; Integrated Security=true"))
            {
                var listaPessoa = new List<Pessoa>();
                var resultado = await connection.QueryAsync<Pessoa>(@"DELETE FROM Pessoa WHERE Id = @id", new { id = id });
                listaPessoa = resultado.ToList();
            }
        }

    }
}



