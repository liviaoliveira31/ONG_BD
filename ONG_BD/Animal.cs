using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG_BD
{
    internal class Animal
    {
        public int CHIP { get; set; }
        public string Familia { get; set; }
        public string Sexo { get; set; }
        public string Raca{ get; set; }
        public string Nome { get; set; }
       

        public Animal()
        {

        }


        #region metodo que cadastra um animal
        public Animal CadastrarAnimal(int c, string f, string s, string r, string n)
        {
            Animal animal = new Animal();
            this.CHIP = c;
            this.Familia = f;
            this.Raca = r;
            this.Sexo = s;
            
            this.Nome = n;

            return animal;
        }
        #endregion

    }
}
