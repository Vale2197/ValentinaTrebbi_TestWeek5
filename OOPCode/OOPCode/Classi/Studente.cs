using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCode.Classi
{
    internal class Studente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoDiNascita { get; set; }
        public Immatricolazione Immatricolazione { get; set; } = new Immatricolazione();
        public List<Esame> Esami { get; set; } = new List<Esame>();
        public bool RichiestaLaurea { get; set; } = false;

        public Studente()
        {

        }

        public Studente(string nome, string cognome, int annoDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = annoDiNascita;
        }

        public string StampaDati()
        {
            return $"nome: {Nome}, Cognome: {Cognome}, data: {AnnoDiNascita}," +
                $"Dettaggli Immatricolazione: numero matricola: {Immatricolazione.Matricola}," +
                $"cfu accumulati: {Immatricolazione.CfuAccumulati}, Data Inizio: {Immatricolazione.DataInizio}," +
                $"Richiesta Laurea: {(RichiestaLaurea == false ? "no" : "si")}, Nome Corso: {Immatricolazione.CorsoLaurea.Nome} " +
                $"cfu necessari per corso richiesto: {Immatricolazione.CorsoLaurea.CfuNecessari},";
        }

        public void StampaListaEsami()
        {

            foreach (var esame in Esami)
            {
              Console.WriteLine($"Nome Corso: {esame.Corso.Nome}, Passato: {(esame.Passato == false ? "no" : "si")}");
            }

          
        }
    }
}
