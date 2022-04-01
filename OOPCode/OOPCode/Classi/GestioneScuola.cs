using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCode.Classi
{
    internal static class GestioneScuola
    {
        public static List<CorsoLaurea> GeneraCorsiLaurea()
        {
            List<CorsoLaurea> list = new List<CorsoLaurea>();

            Corso corsoMat = new Corso("Algebra", 3);
            Corso corsoLettere = new Corso("LettereDue", 3);
            Corso corsoInformatica = new Corso("Informatica", 3);
            Corso corsoFisica = new Corso("Fisica1", 3);

            //Esame esameMat = new Esame(corsoMat);
            //Esame esameInform = new Esame(corsoInformatica);
            //Esame esameFisi = new Esame(corsoFisica);
            //Esame esameLettere = new Esame(corsoLettere);

            CorsoLaurea corsoLaurea1 = new CorsoLaurea(NomeCorso.Lettere, 3, 10);
            corsoLaurea1.Corsi.Add(corsoLettere);

            CorsoLaurea corsoLaurea2 = new CorsoLaurea(NomeCorso.Informatica, 3, 6);
            corsoLaurea2.Corsi.Add(corsoInformatica);
            corsoLaurea2.Corsi.Add(corsoFisica);

            CorsoLaurea corsoLaurea3 = new CorsoLaurea(NomeCorso.Matematica, 3, 4);
            corsoLaurea3.Corsi.Add(corsoMat);

            list.Add(corsoLaurea1);
            list.Add(corsoLaurea2);
            list.Add(corsoLaurea3);

            return list;

        }
        public static List<Corso> GeneraCorsi()
        {
            List<Corso> corsi = new List<Corso>();

            Corso corsoMat = new Corso("Algebra", 3);
            Corso corsoMat1 = new Corso("AlgebraDue", 3);
            Corso corsoInformatica = new Corso("Informatica", 3);
            Corso corsoFisica = new Corso("Fisica1", 3);
            corsi.Add(corsoMat);
            corsi.Add(corsoMat1);
            corsi.Add(corsoInformatica);
            corsi.Add(corsoFisica);

            return corsi;
        }

        static int LeggiNumero()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("numero non corretto");
            }

            return num;
        }
        public static void RichiediEsame(ref Studente studente)
        {
            //NOTA:Uno studente può richiedere un esame solo se esso è presente 
            //    nel Corso di Laurea associato allo studente, se i CFU del corso associato 
            //    all’esame non superino i CFU massimi del Corso di laurea e se non ha il flag 
            //    RichiestaLaurea assegnato a vero. Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla lista Esami.

            Corso corsoScelto = null;

            foreach (var corso in studente.Immatricolazione.CorsoLaurea.Corsi)
            {

                Console.WriteLine($" Esame disponibile: {corso.Nome}");

            }

            Console.WriteLine($"scegli l'esame a cuoi vuoi partecipare inserendo il nome");

            string nome = Console.ReadLine();
            bool esiste = false;

            do
            {

                foreach (var item in studente.Immatricolazione.CorsoLaurea.Corsi)
                {

                    if (nome.ToLower() == item.Nome.ToLower())
                    {
                        corsoScelto = item;
                        Console.WriteLine($"l'esame di {item.Nome} è stato assegnato..Verifica..");
                        Esame esame = new Esame(item);
                        VerificaPossibilitaEsame(ref studente, esame);
                        esiste = true;
                    }

                }
                if (!esiste)
                {
                    Console.WriteLine("nome errato, reinserisci");

                }
            } while (!esiste);








        }

        public static void VerificaPossibilitaEsame( ref Studente studente, Esame esame)
        {

            if (studente.Immatricolazione.CorsoLaurea.Corsi.Contains(esame.Corso)
                && esame.Corso.Cfu <= studente.Immatricolazione.CorsoLaurea.CfuNecessari
                && studente.RichiestaLaurea == false)
            {
                
                //bool hoQuestoEsame = studente.Esami.ForEach(x => {
                //    if (x.Corso.Nome == esame.Corso.Nome)
                //        return true;
                //});
                    Console.WriteLine("sei iscritto all'esame");
                    studente.Esami.Add(esame);
                  
            }
            else
            {
                Console.WriteLine("non puoi richiedere l'esame");
            }

        }

        //l'esame viene passato sempre
        public static void EsamePassato(ref Studente studente) //
        {
            //NOTA:Scrivere un metodo EsamePassato che, dato un esame, vada ad aggiornare i 
            //    CFU accumulati dallo studente, metta il flag Passato sull’esame e verifichi se con 
            //    tale esame sono stati raggiunti i CFU necessari per richiedere la laurea (e quindi metta il flag Richiestalaurea a true);


            if (studente.Esami != null)
            {
                foreach (var esame in studente.Esami)
                {
                    if (esame.Passato == false)
                    {

                        esame.Passato = true;

                        studente.Immatricolazione.CfuAccumulati += esame.Corso.Cfu;
                    }
                }
            }


            if (studente.Immatricolazione.CfuAccumulati >= studente.Immatricolazione.CorsoLaurea.CfuNecessari)
            {
                studente.RichiestaLaurea = true;
                Console.WriteLine("hai passato l'esame e puoi richiedere la laurea");
            }
            else
            {
                Console.WriteLine("hai passato l'esame ma ancora non puoi richiedere la laurea");

                studente.RichiestaLaurea = false;
            }
        }

    }
}
