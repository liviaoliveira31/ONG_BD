using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG_BD
{
    internal class Banco
    {
        string Conexao = "Data Source = localhost; Initial Catalog = ONG; User ID = sa; Password=Livia_Livia31;"; //Tela de login do sqlserver. começa a conexao, insere seu usuario e valida a senha

        public Banco()
        {

        }
        public string Caminho()
        {
            return Conexao; //retorna essa conexao pra onde for chamado
        }
    }
}
