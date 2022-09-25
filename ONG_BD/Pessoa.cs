using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG_BD
{
    internal class Pessoa
    {

        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public Pessoa()
        {

        }

        #region metodo para cadastrar uma pessoa
        public Pessoa CadastrarPessoa(string cpf, string n, string t, string s, string r, string b, int num, string c, string est)
        {
            Pessoa p = new Pessoa();
            this.CPF = cpf;
            this.Nome = n;
            this.Telefone = t;
            this.Sexo = s;
            this.Rua = r;
            this.Bairro = b;
            this.Numero = num;
            this.Cidade = c;
            this.Estado = est;

            return p;

        }
        #endregion


    }
}
