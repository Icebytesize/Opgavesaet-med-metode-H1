using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgavesaet_med_metode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            bool programkøre = true;
            while (programkøre)
            {
                int input = 0;
                Console.Clear();
                Console.WriteLine("Velkommen til programmet opgaver med metode.");
                Console.WriteLine("\nHer kan du vælge hvilken opgave du vil se løsning af, du kan vælge mellem følgende opgaver");
                Console.WriteLine("1: Retunering af en streng");
                Console.WriteLine("2: Udskrivning af brugerinput");
                Console.WriteLine("3: Summen af tre tal, subtraktion af tre tal, multiplikation af tre tal og summen af to tal divideret med et tredje");
                Console.WriteLine("4: Navn og alder med gruppeinddeling");
                Console.WriteLine("5: Opdeling af komma-separeret streng");
                Console.WriteLine("6: Gæt et tal-spil");
                Console.WriteLine("99: Afslut program");
                Console.Write("\n> ");
                int.TryParse(Console.ReadLine(), out input);
                Console.Clear();

                if (input == 1) //Udskrinver hvad der bliver retuneret fra metoden til konsollen
                {
                    Console.Write(RetuneringAfEnStreng());
                    Console.ReadKey();
                }
                else if (input == 2) //Kalder metoden, hvor der modsat i input 1 er metoden der udskriver til konsollen, det den udskriver er så den tekststreng brugeren har indtastet
                {
                    Console.Write("Indtast en tekststreng: ");
                    string tekst = Console.ReadLine();
                    Console.Clear();
                    UdskrivningAfBrugerInput(tekst);
                    Console.ReadKey();
                }
                else if (input == 3) //Valgmulighed 3 bliver brugeren bedt om at indtaste 3 tal, de tal bliver så sendt til 4 forskellig metoder, der returnere helholdsvis Summen, Subtraktionen, multiplaktionen og summen af de 2 første tal divideret med det 3 tal.
                {
                    double tal1, tal2, tal3;
                    Console.Write("Du skal indtaste tre tal.");
                    Console.Write("\nIndtast dit første tal: ");
                    double.TryParse(Console.ReadLine(), out tal1);
                    Console.Write("Indtast dit andet tal: ");
                    double.TryParse(Console.ReadLine(), out tal2);
                    Console.Write("Indtast dit tredje tal: ");
                    double.TryParse(Console.ReadLine(), out tal3);
                    Summen(tal1, tal2, tal3);
                    Subtraktion(tal1, tal2, tal3);
                    Multiplikation(tal1, tal2, tal3);
                    Sum2Div1(tal1, tal2, tal3);
                    Console.ReadKey();
                }
                else if (input == 4) //Brugeren indtaster en string Navn og en Int alder, Sender det til en metoder der modtager det og retunere en besked på baggrund af disse input
                {
                    string navn;
                    int alder;
                    Console.Write("Indtast dit navn: ");
                    navn = Console.ReadLine();
                    Console.Write("Indtast din alder: ");
                    int.TryParse(Console.ReadLine(), out alder);

                    Console.Write(NavnAlderGruppe(navn, alder));
                    Console.ReadKey();
                }
                else if (input == 5) //Her bliver brugeren bedt om at indtastet en string med tal brudt op af kommaer, den string bliver sendt til en metode der splitter den og indføre den i et array, hvorefter der bruges en for-løøke til at udskrive alle tallene i arrayet
                {
                    // Her bliver brugeren bedt om at indtaste en streng med tal adskilt af kommaer:
                    Console.Write("Indtast en masse tal, brudt op af kommaer: ");
                    string masseTal = Console.ReadLine();

                    // Her bliver stringen sendt som parameter for at oprette arrayet
                    int[] talArray = OpdelingAfTal(masseTal);

                    Console.WriteLine("\nDine tal er");
                    for (int i = 0; i < talArray.Length; i++)
                    {
                        Console.WriteLine($"Tal {i + 1}: {talArray[i]}");
                    }
                    Console.ReadKey();

                }

                else { Console.WriteLine("Input ikke forstået, prøv igen"); Console.ReadKey(); }
            }
        }

        /// <summary>
        /// Denne metode retunere en string med det faste inhold "Hello World!
        /// </summary>
        /// <returns></returns>
        static string RetuneringAfEnStreng()
        {
            return "Hello World!";
        }

        /// <summary>
        /// Denne metode udskriver til konsollen "Du indtastede: " samt den tekst brugeren har indtastet
        /// </summary>
        /// <param name="tekst"></param>
        static void UdskrivningAfBrugerInput(string tekst)
        {
            Console.Write($"Du indtastede: {tekst}");
        }

        /// <summary>
        /// Denne metode udskriver summen af tre, indtastet af brugeren, tal.
        /// </summary>
        /// <param name="tal1"></param>
        /// <param name="tal2"></param>
        /// <param name="tal3"></param>
        static void Summen(double tal1, double tal2, double tal3)
        {
            Console.WriteLine($"Summen af dine tal indtastede er: {tal1 + tal2 + tal3}");
        }

        /// <summary>
        /// Denne metode udkriver 3, indtastet af brugere, tal trukket fra hinanden.
        /// </summary>
        /// <param name="tal1"></param>
        /// <param name="tal2"></param>
        /// <param name="tal3"></param>
        static void Subtraktion(double tal1, double tal2, double tal3)
        { 
            Console.WriteLine($"Dine tal trukket fra hinanden er: {tal1 - tal2 - tal3}");
        }

        /// <summary>
        /// Denne metode udskriver 3, indtastet af brugeren, tal gangen med hinanden
        /// </summary>
        /// <param name="tal1"></param>
        /// <param name="tal2"></param>
        /// <param name="tal3"></param>
        static void Multiplikation(double tal1, double tal2, double tal3)
        {
            Console.WriteLine($"Dine tal ganget med hinanden er: {tal1 * tal2 * tal3}");
        }

        /// <summary>
        /// Denne metode udskriver summen af de 2 første tal divideret med det 3 tal.
        /// </summary>
        /// <param name="tal1"></param>
        /// <param name="tal2"></param>
        /// <param name="tal3"></param>
        static void Sum2Div1(double tal1, double tal2, double tal3)
        {
            Console.WriteLine($"Summen af dine to første tal divideret med dit tredje tal er: {(tal1+tal2)/tal3}");
        }

        /// <summary>
        /// Denne metode retunere en string, med brugerens Navn samt den gruppe de tilhøre, på baggrund af den alder brugeren har indtastet.
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="alder"></param>
        /// <returns></returns>
        static string NavnAlderGruppe(string navn, int alder)
        {
            string gruppe;
            if (alder >= 19) gruppe = "Nu begynder livet at blive alvor";
            else if (alder >= 6) gruppe = "Du går i skole";
            else if (alder >= 4) gruppe = "Du er i børnehave";
            else if (alder >= 2) gruppe = "Du er i dagpleje eller vuggestue";
            else if (alder >= 0) gruppe = "Du er nyfødt";
            else { return "Fejl"; }
            
            return $"{navn}: {gruppe}";
        }

        /// <summary>
        /// Denne metode modtager en string, deler den i en string array, tæller hvor mange entrees der er i arrayet, kopier det over i et int array, som så bæiver retuneret 
        /// </summary>
        /// <param name="masseTal">Rækken af tal opdelt af kommaer</param>
        /// <returns></returns>
        static int[] OpdelingAfTal(string masseTal)
        {
            string[] dele = masseTal.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] række = new int[dele.Length];

            for (int i = 0; i < dele.Length; i++)
            {
                int.TryParse(dele[i], out række[i]);
            }
            return række;
        }
    }
}
