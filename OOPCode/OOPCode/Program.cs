// See https://aka.ms/new-console-template for more information
using OOPCode.Classi;

Console.WriteLine("Hello, World!");
//All’accesso, uno studente può:
//-Prenotarsi ad un Esame
//NOTA:Uno studente può richiedere un esame solo se esso è presente 
//    nel Corso di Laurea associato allo studente, se i CFU del corso associato 
//    all’esame non superino i CFU massimi del Corso di laurea e se non ha il flag 
//    RichiestaLaurea assegnato a vero. Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla lista Esami.
//-Verbalizzare un Esame prenotato.
//NOTA:Scrivere un metodo EsamePassato che, dato un esame, vada ad aggiornare i 
//    CFU accumulati dallo studente, metta il flag Passato sull’esame e verifichi se con 
//    tale esame sono stati raggiunti i CFU necessari per richiedere la laurea (e quindi metta il flag Richiestalaurea a true);

//Consigli:
//-Potrebbe essere utile creare un paio di metodi ad hoc per creare al 
//    volo delle liste di corsi, corsi di laurea…
//-Visto che le classi sono collegate strettamente l’una con le altre, 
//verificate l’inizializzazione di ciascuna sia adeguata e che i riferimenti siano corretti.

Studente io = new Studente("Vale", "trebbi", 1997);

List<CorsoLaurea> corsiLaurea = GestioneScuola.GeneraCorsiLaurea();

Corso corsoLettere = new Corso("Lettere", 2);

Esame esameLettere = new Esame(corsoLettere);

io.Immatricolazione.CorsoLaurea.Corsi.Add(corsoLettere);

Studente studente2 = new Studente("Jim", "Alpert", 1990);

int choice = 0;
Studente studenteCorrente = null;
bool registrato = studenteCorrente == null ? false : true;
do
{
    Menu();
    choice = LeggiNumero();
    Esame esameCorrente;

    switch (choice)
    {
        case 1:
            if (registrato)
            {

                GestioneScuola.RichiediEsame(ref studenteCorrente);
            }
            else
            {
                Console.WriteLine("non sei ancora registrato");
            }
            break;
        case 2:
            if (registrato)
            {

                GestioneScuola.EsamePassato(ref studenteCorrente);
            }
            else
            {
                Console.WriteLine("non sei ancora registrato");
            }

            break;
        case 3:
            if (registrato)
            {

                Console.WriteLine(studenteCorrente.StampaDati());
                studenteCorrente.StampaListaEsami();
            }
            else
            {
                Console.WriteLine("non sei ancora registrato");
            }
            break;
        case 4:
            if (!registrato)
            {
                studenteCorrente = Registrati(corsiLaurea);
                registrato = true;
            }
            else
            {
                Console.WriteLine("sei gia registrato");
            }
            break;
        case 5:
            StampaCorsiLaurea(corsiLaurea);
            break;
        default:
            Console.WriteLine("scelta non valida");
            break;
    }

} while (true);

static void Menu()
{
    Console.WriteLine("1- registrati a esame");
    Console.WriteLine("2- Esame Risultati");
    Console.WriteLine("3- Stampa tutti i dettagli");
    Console.WriteLine("4- Registrati");
    Console.WriteLine("5- Stampa Corsi disponibili");
}



//static void RegistraStudente(List<Studente> studenti)
//{
//    int lastMatricaola = studenti.Last(x => return x.Immatricolazione.Matricola);

//}

static int LeggiNumero()
{
    int num;
    while (!int.TryParse(Console.ReadLine(), out num))
    {
        Console.WriteLine("numero non corretto");
    }

    return num;
}

static Studente Registrati(List<CorsoLaurea> corsi)
{

    Studente studente = new Studente();
    Console.WriteLine("inserisci Nome");
    studente.Nome = Console.ReadLine();
    Console.WriteLine("inserisci Cognome");
    studente.Cognome = Console.ReadLine();
    Console.WriteLine("inserisci DataNascita");
    studente.AnnoDiNascita = LeggiNumero();


    Console.WriteLine("a che corso vuoi iscriverti? digita il nome del corso di laurea");
    StampaCorsiLaurea(corsi);




    bool done = false;
    do
    {
        string nome = Console.ReadLine();

        foreach (var item in corsi)
        {
            if (item.Nome.ToString().ToLower() == nome.ToLower())
            {
                done = true;
                studente.Immatricolazione.CorsoLaurea = item;
            }
        }
        if (done)
        {

            Console.WriteLine("sei iscritto al corso");
        }
        else
        {

            Console.WriteLine("corso errato, reinserisci");

        }


    } while (!done);
    return studente;
}

static void StampaCorsiLaurea(List<CorsoLaurea> corsiLaurea)
{
    foreach (CorsoLaurea corsoL in corsiLaurea)
    {
        Console.WriteLine($"Nome Corso Laurea: {corsoL.Nome}, CFU necessari: {corsoL.CfuNecessari}: \n Esami:");

        foreach (var corso in corsoL.Corsi)
        {
            Console.WriteLine($"corso:{corso.Nome}, CFUricevuti: {corso.Cfu}");
        }
    }
}

