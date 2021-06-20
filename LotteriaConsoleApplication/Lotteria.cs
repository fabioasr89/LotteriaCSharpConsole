using System;
using System.Collections.Generic;
using System.Text;

namespace LotteriaConsoleApplication
{
    class Lotteria
    {
        public Lotteria() { }
        public  int[,] generaMatriceCasualeUnivoca(Random Rand) {
            int Casuale = 0;
            int[,] numeriGenerati = new int[10, 10];
            int[] lista = new int[100];
            int Riga = 0;
            int Colonna = 0;
            for (int i=0;i<100;) {
                int j = 0;
                Casuale = Rand.Next(1, 200);
                int semaforo = 0;
                for (j=0;j<i && j>=0;j++)
                    {
                        if (Casuale == lista[j])
                        {
                            //significa che il numero casuale appena generato, è stato già generato in precedenza
                            //usciamo dal ciclo e rigeneriamo di nuovo lo pseudocasuale
                            semaforo++;
                            break;
                        }
                           
                }
                if (semaforo == 0)
                {
                    //se il numero casuale non è stato già generato in precedenza, associamolo alla riga e incrementiamo il contatore
                    lista[i] = Casuale;
                    i++;
                    //popolo la matrice 10x10 inizialmente vuota
                    if(Riga<10 && Colonna < 10)
                    {
                        numeriGenerati[Riga, Colonna] = Casuale;
                    }
                    if (Colonna < 10)
                    {
                        Colonna++;
                    }
                    if (Colonna > 9)
                    {
                        Riga++;
                        Colonna = 0;
                    }
                }
            }

            return numeriGenerati;

        }


        public  Boolean validaInserimento(int riga, int colonna,int numeroGenerato, int[,] listaInteri) {
            Boolean inserisci = true;
            if(riga==0 && colonna==0 && listaInteri != null)
            {
                return inserisci ;
            }
            else if((riga!=0 || colonna!=0) && listaInteri != null)
            {
                int Numero = 0;
                for(int i=riga;i>=0 && i <= riga; i--)
                {
                    int j = colonna;
                    for(j=colonna;j>=0 && j <=colonna; j--)
                    {
                        //dalla posizione i,j a cui dobbiamo assegnare uno pseudocasuale, scorriamo da 0 a j le colonne
                        //per verificare che non sia presente già un numero uguale a quello generato. Fatto il controllo sulla riga i-esima,
                        //si procede per iterazione sulla riga i-1 e la colonne da 0 a j, fino ad arrivare alla riga i=0 (la prima)
                        //se troviamo un numero uguale a quello pseudocasuale già generato,usciamo dal ciclo e rigeneriamo il numero
                        Numero = listaInteri[i, j];
                        if (Numero == numeroGenerato)
                        {
                            inserisci = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                inserisci = false;
            }
            return inserisci;
        
        }
    }
}
