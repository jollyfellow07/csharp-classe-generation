// See https://aka.ms/new-console-template for more information



/************************************************VARIABILI GLOBALI*****************************************************/
int postiAlunniOccupati = 0;
int postiAlunniDisponibili = 10;
string[] nomeAlunno = new string[postiAlunniDisponibili];
string[] cognomeAlunno = new string[postiAlunniDisponibili];
int[] etaAlunno = new int[postiAlunniDisponibili];


/***********************************************FUNZIONI*****************************************************************/
//stampa array
void stampaArray(string[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i]);
        if (i < array.Length - 1)
        {
            Console.Write(", \t");
        }
    }
    Console.Write("]\n");
}
//stampa array di interi
void stampaArrayInt(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i]);
        if (i < array.Length - 1)
        {
            Console.Write(", \t");
        }
    }
    Console.Write("]\n");
}
//funzione per aggiungere l'alunno
void aggiungiAlunno(string nome, string cognome, int eta)
{
    if (postiAlunniOccupati < postiAlunniDisponibili)
    {
        etaAlunno[postiAlunniOccupati] = eta;
        nomeAlunno[postiAlunniOccupati] = nome;
        cognomeAlunno[postiAlunniOccupati] = cognome;
        postiAlunniOccupati++;
    }
    else
    {
        Console.WriteLine("mi dispiace la classe è piena\n");
    }
}


void rimuoviAlunno()
{
    if (postiAlunniOccupati > 0)
    {
        postiAlunniOccupati--;
        nomeAlunno[postiAlunniOccupati] = " ";
        etaAlunno[postiAlunniOccupati] = 0;
    }
    else
    {
        Console.WriteLine("mi dispiace la classe è vuota, non puoi rimuovere nessun alunno!\n");
    }
}

double etaMediaClasse()
{
    int somma = 0;
    for (int i = 0; i < etaAlunno.Length; i++)
    {
        somma += etaAlunno[i];
    }
    double media = (double)somma / postiAlunniOccupati;
    return media;
}
int etaPiuGiovane()
{
    int alunnoGiovane = etaAlunno[0];
    for (int i = 1; i < postiAlunniOccupati; i++)
    {
        if (etaAlunno[i] < alunnoGiovane)
        {
            alunnoGiovane = etaAlunno[i];
        }
    }
    return alunnoGiovane;
}

int etaPiuVecchia()
{
    int alunnoVecchio = etaAlunno[0];
    for (int i = 1; i < postiAlunniOccupati; i++)
    {
        if (etaAlunno[i] > alunnoVecchio)
        {
            alunnoVecchio = etaAlunno[i];
        }
    }
    return alunnoVecchio;

}
/*****************************************PROGRAMMA PRINCIPALE***********************************************************/
while (true)
{
    Console.WriteLine("\nvuoi aggiungere un alunno? [aggiungi/rimuovi]");
    string risposta = Console.ReadLine();
    switch (risposta)
    {
        case ("aggiungi"):
            Console.WriteLine("\nImmetti nome dell' alunno:  ");
            string nome = (Console.ReadLine());
            Console.WriteLine("Immetti cognome dell' alunno:  ");
            string cognome = (Console.ReadLine());
            Console.WriteLine("Immetti l'eta dell'alunno");
            int eta = int.Parse(Console.ReadLine());
            if (eta >= 14 && eta <= 50)
            {
                aggiungiAlunno(nome, cognome, eta);
            }
            else
                Console.WriteLine("mi dispiace ma in questa classe non sono ammessi over 50 e under 14 ! ");
            break;
        case ("rimuovi"):
            rimuoviAlunno();
            break;
        default:
            Console.WriteLine("Mi dispiace scelta non corretta, ricontrolla testo digitato");
            break;
    }
    bool input = false;
    do
    {
        Console.WriteLine("Vuoi stampare le statistiche? [si/no]");
        string statistiche = Console.ReadLine();
        switch (statistiche)
        {
            case ("si"):
                Console.Clear();
                Console.WriteLine("attualmente nella classe sono occupati: " + postiAlunniOccupati + " posti su 10\n");
                Console.Write("nomi: \t");
                stampaArray(nomeAlunno);
                Console.Write("Cognomi:");
                stampaArray(cognomeAlunno);
                Console.Write("eta: \t");
                stampaArrayInt(etaAlunno);
                double media = etaMediaClasse();
                Console.WriteLine("\n\n l'eta media della classe è: " + media);
                int etaMinima = etaPiuGiovane();
                int etaMaxima = etaPiuVecchia();
                Console.WriteLine(etaMinima);
                Console.WriteLine(etaMaxima); 
                input = true;
                break;
            case ("no"):
                Console.Clear();
                input = true;
                break;
            default:
                break;
        }
    } while (input == false);

}
