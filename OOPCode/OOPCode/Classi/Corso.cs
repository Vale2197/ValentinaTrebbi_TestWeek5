using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCode.Classi
{
    internal class Corso
    {
        //Nome e dei CFU.
        public string Nome { get; set; }
        public int Cfu { get; set; }

        public Corso()
        {

        }
        public Corso(string nome, int cfu)
        {
            Nome = nome;
            Cfu = cfu;
        }
    }
}
