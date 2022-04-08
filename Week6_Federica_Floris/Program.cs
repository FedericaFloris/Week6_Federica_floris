// See https://aka.ms/new-console-template for more information
using Week6_Federica_Floris;
Console.WriteLine("Benvenuto");

//RISPOSTE DOMANDE DI TEORIA:
//1) A-B-E-G
//2) B-D
//3) C


//Implementare una Console App che tramite menù permetta di:
//-Mostrare tutti gli agenti di polizia
//- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
//- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input
//- Inserire un nuovo agente solo se non è già presente nel database

Console.WriteLine("----Distretto------");
RepositoryAgenteDBAdo repositoryAgenti = new RepositoryAgenteDBAdo();
bool continua = true;
while (continua)
{
    PrintMenu();
    int scelta;
    do
    {
        Console.WriteLine("Scegli tra le possibili opzioni:");
    } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

    switch (scelta)
    {
        case 1:
            Console.WriteLine("Questi sono tutti gli agenti");
            var listaagenti =  repositoryAgenti.VediTutti();
            foreach(var item in listaagenti)
            {
                Console.WriteLine(item.ToString());
            }
            break;
        case 2:
            //- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
            Console.WriteLine("Inserisci l'area dell'agente che vuoi cercare");
            string area = Console.ReadLine();
            List<Agente> agenteArea = repositoryAgenti.CercaAgenteByArea(area);
            foreach(var item in agenteArea)
            {
                Console.WriteLine(item.ToString());
            }
           
            
            break;
        case 3:
            //- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input
            Console.WriteLine("Inserisci anni di servizio degli agenti che vuoi visualizzare");
            int anni;
            do
            {
                Console.WriteLine("Scegli tra le possibili opzioni:");
            } while (!(int.TryParse(Console.ReadLine(), out anni)));
            repositoryAgenti.CercaAgenteByAnniServizio(anni);

            break;
        case 4:
            //- Inserire un nuovo agente solo se non è già presente nel database
            
            string cf1;
           
            do
            {
                Console.WriteLine("inserisci il cf");
                cf1 = Console.ReadLine();
            } while (repositoryAgenti.CercaAgenteByCF(cf1) != null);

            Console.WriteLine("Insersci Nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Insersci Cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Insersci AreaGeografica");
            string areaGeografica = Console.ReadLine();
            int annoInizioAttivita;
            Console.WriteLine("Inserisci l anno in cui hai iniziato il servizio:");
            while(!(int.TryParse(Console.ReadLine(), out annoInizioAttivita)))
            {
                Console.WriteLine("Non hai inserito un numero riprova");
            }
            Agente agente = new Agente(nome, cognome, cf1, areaGeografica, annoInizioAttivita);
            bool risultato = repositoryAgenti.Aggiungi(agente);
            if (risultato)
            {
                Console.WriteLine("Aggiunto");
            }
            else
            {
                Console.WriteLine("l'AGGIUNTA NON E' ANDATA A BUON FINE");
            }
            break;
        case 0:
            Console.WriteLine("Arrivederci");
            continua = false;
           
            break;
            

            
    }


}


void PrintMenu()
{
    Console.WriteLine("1-Visualizza tutti gli agenti di polizia");
    Console.WriteLine("2-Visualizza agenti assegnati ad un area");
    Console.WriteLine("3-Visualizzare gli agenti in base agli anni di servizio");
    Console.WriteLine("4-Aggiungi agente");
}






