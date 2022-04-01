using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCode.Classi
{
    internal class Immatricolazione
    {
        //Matricola(La matricola dello studente deve essere univoca, autogenerata e read-only)
        //DataInizio
        //CorsoDiLaurea
        //FuoriCorso
        //CFUAccumulati

        public static int GlobalMatricola;
        public int Matricola { get; }
        public DateTime DataInizio { get; set; } = DateTime.Now;
        public CorsoLaurea CorsoLaurea { get; set; } = new CorsoLaurea();
        public int CfuAccumulati { get; set; }
        public bool FuoriCorso { get; set; } = false;

        public Immatricolazione()
        {

        }

        public Immatricolazione(DateTime dataInizio, CorsoLaurea corsoLaurea)
        {
            DataInizio = dataInizio;
            CorsoLaurea = corsoLaurea;
            Matricola = Interlocked.Increment(ref GlobalMatricola);
        }


    }
}
