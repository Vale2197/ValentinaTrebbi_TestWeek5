using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCode.Classi
{
    internal class CorsoLaurea
    {
        //Nome,
        //AnniDiCorso,
        //Cfu per ottenere la laurea
        //lista di corsi associati.
        //I possibili nomi dei Corsi di Laurea possono essere solo i seguenti: Matematica, Fisica, Informatica, Ingegneria, Lettere.
        public NomeCorso Nome { get; set; }
        public int AnniDiCorso { get; set; }
        public int CfuNecessari { get; set; }
        public List<Corso> Corsi { get; set; } = new List<Corso>();

        public CorsoLaurea()
        {

        }
        public CorsoLaurea(NomeCorso nomeCorso, int anniDiCorso, int cfuNecessari)
        {
            Nome = nomeCorso;
            AnniDiCorso = anniDiCorso;
            CfuNecessari = cfuNecessari;
        }
    }

    enum NomeCorso : int
    {
        Matematica = 1,
            Fisica, 
       Informatica,
        Ingegneria,
           Lettere,
    }

  
}
