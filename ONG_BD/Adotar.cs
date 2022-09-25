using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG_BD
{
    internal class Adotar
    {

        public string CPF { get; set; }
        public string CHIP { get; set; }

        public Adotar()
        {

        }

        public Adotar CadastrarAdocao(string cpf, string chip)
        {
            Adotar a = new Adotar();
            this.CPF = cpf;
            this.CHIP = chip;
            return a;
        }
    }
}
