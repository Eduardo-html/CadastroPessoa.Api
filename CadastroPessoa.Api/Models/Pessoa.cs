using CadastroPessoa.Api.Enum;

namespace CadastroPessoa.Api.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string  Sexo { get; set; }

        public EnunSigno? Signo { get; set; }


        public Pessoa()
        {
        }

        public Pessoa(string nome, int idade, string sexo, EnunSigno signo)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Sexo = sexo;
            this.Signo = signo;
        }
    }
}
