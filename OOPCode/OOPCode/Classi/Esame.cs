using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCode.Classi
{
    internal class Esame
    {
        //riferisce ad un corso e tiene 
        //conto se esso è stato passato.
        public Corso Corso { get; set; } = new Corso();

        public bool Passato { get; set; } = false;

        public Esame(Corso corso)
        {
            Corso = corso;
        }
        public Esame()
        {
            
        }



    }
}
