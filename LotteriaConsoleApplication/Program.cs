using System;

namespace LotteriaConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Lotteria lotteria = new Lotteria();
            Random Random = null;
            int[,] Numeri = new int[10, 10];
            string NumeroInserito = null;
            int[] NumeriDigitati = new int[3];
            int Estrazioni = 2;
            try
            {
                Random = new Random();
                Numeri = lotteria.generaMatriceCasualeUnivoca(Random);

                Console.WriteLine("Matrice casuale generata");
                int Count = 0;
                do
                {
                    Console.WriteLine("Digita il numero:");
                    NumeroInserito = Console.ReadLine();
                    if (NumeroInserito != null)
                    {
                        try
                        {
                            int n = int.Parse(NumeroInserito);
                            if (Count < 3)
                            {
                                NumeriDigitati[Count] = n;
                                Count++;
                            }

                        }
                        catch (Exception e)
                        {
                            Estrazioni = -1;
                            Console.WriteLine("Non hai inserito un numero. Il gioco è finito");
                        }
                        Estrazioni--;
                    }
                    else
                    {
                        Estrazioni = -1;
                    }
                } while (Estrazioni >= 0);
                Count = 0;
                if (NumeriDigitati.Length > 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            int VALORE = Numeri[i, j];
                            for (int k = 0; k < 3; k++)
                            {
                                if (VALORE == NumeriDigitati[k])
                                {
                                    Console.WriteLine("Il numero " + VALORE + " " + "è presente nella matrice pseuodocasuale");
                                    Count++;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Numeri digitati:");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(NumeriDigitati[i]);
                        if (i <= 2)
                        {
                            Console.Write(",");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Matrice pseudocasuale generata:");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(Numeri[i, j]);
                        if (j < 9)
                        {
                            Console.Write(",");
                        }

                    }
                    Console.WriteLine();
                }
                Console.WriteLine("********************");


                Console.WriteLine("Hai indovinato " + Count + " " + "numeri dell'estrazione");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
