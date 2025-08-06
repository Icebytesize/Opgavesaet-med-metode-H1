using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        /// <summary>
        /// Denne metode laver en menu, denne menu kan man vælge nogle valgmuligheder og køre.
        /// </summary>
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
                Console.WriteLine("7: Temperatur omregner (Opgave 7a og 7c)");
                Console.WriteLine("8: Tal til dec, bi og hex (Opgave 7b)");
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

                else if (input == 6) //Gæt et tal spil, starter med at generere et tilfældigt tal mellem, brugeren har derefter 5 chancer for at gætte tallet, efter hvert gæt fortæller programmet om det tal brugeren har gættet er støøre eller mindre end det tilfældige tal
                {
                    bool spilKøre = true;
                    int tilfældigtTal, gættetTal, antalForsøg = 5;
                    tilfældigtTal = TilfældigtTal();

                    Console.Write("Velkommen til gæt et tal spil, spillet starter når du trykker på en tast");
                    Console.ReadKey();
                    while (spilKøre)
                    {
                        Console.Clear();


                        Console.Write($"Antal gæt tilbage: {antalForsøg}");

                        Console.Write("\n\nIndtast et tal mellem 1 og 25\n\n> ");
                        int.TryParse(Console.ReadLine(), out gættetTal);
                        if (gættetTal < 1 || gættetTal > 25) //Hvis gættet tal er udenfor parameter
                        {
                            Console.Clear();
                            Console.WriteLine("Input ikke forstået, prøv igen");
                            Console.ReadKey();
                        }
                        else if (antalForsøg > 0)
                        {
                            antalForsøg--;
                            if (antalForsøg > 0)
                            {
                                ForHøjtEllerLavt(tilfældigtTal, gættetTal);
                            }
                            spilKøre = ErGætRigtigt(tilfældigtTal, gættetTal, antalForsøg);

                        }
                        if (antalForsøg <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Du har desværre ikke flere gæt, spillet er slut. DU HAR TABT");
                            Console.ReadKey();
                            spilKøre = false;
                        }

                    }


                }

                else if (input == 7) //Omregn temperatur, her skal brugeren vælge hvilken enhedstype de vil regne fra og indtaste temperaturen, så bliver de 2 valg sendt til en metode der sender den omregnede temperatur tilbage
                {
                    bool vælgTempUnit = true;
                    int tempUnit = 0;
                    double temp;
                    while (vælgTempUnit)
                    {
                        Console.Clear();
                        Console.Write("Ønsker du at regne fra\n1: Celsius\neller\n2: Fahrenheit\n\n> ");
                        int.TryParse(Console.ReadLine(), out tempUnit);
                        if (tempUnit == 1 || tempUnit == 2)
                        {
                            vælgTempUnit = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Input ikke forstået, prøv igen.");
                        }
                    }
                    Console.Write("Indtast den temperatur du gerne vil omregne\n\n>  ");
                    double.TryParse(Console.ReadLine(), out temp);
                    Console.Clear();

                    TempOmregner(tempUnit, temp);
                }

                else if (input == 8) //Brugeren indtaster et heltal, der bliver sendt til 3 forskellig metoder der henholdsvis retunere et dec, hex og bi tal 
                {
                    bool indtastHelTal = true;
                    int helTal = -1;
                    while (indtastHelTal)
                    {
                        Console.Clear();
                        Console.Write("Indtast det posetive heltal du vil omregne til decimal, hex og binær\n\n>  ");
                        int.TryParse(Console.ReadLine(), out helTal);
                        if (helTal >= 0)
                        {
                            Console.WriteLine($"Decimal: {DecConverter(helTal)}");
                            Console.WriteLine($"Hex: {HexConverter(helTal)}");
                            Console.WriteLine($"Binær: {BiConverter(helTal)}");
                            Console.ReadKey();
                            indtastHelTal = false;
                        }

                        else
                        {
                            Console.Write("Input ikke forstået, prøv igen");
                            Console.ReadKey();
                        }
                    }
                }

                else if (input == 99) // til afslutning af programmet
                {
                    Console.WriteLine("Programmet afsluttes, hav en god dag");
                    programkøre = false;
                }

                else { Console.Write("Input ikke forstået, prøv igen"); Console.ReadKey(); }
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

        /// <summary>
        /// Denne metode generere et tilfædligt tal mellem 1 og 25
        /// </summary>
        /// <returns></returns>
        static int TilfældigtTal()
        {
            Random tal = new Random();
            int tilfældigtTal = tal.Next(1, 26); //1 er minimum, 26 er ekskluderet derfor mellem 1 og 25
            return tilfældigtTal;
        }

        /// <summary>
        /// Denne metode tjekker om det tal brugeren har gættet på, er det rigtige tal. Hvis det er, giver spillet brugeren en sejrsbesked og afslutter spillet. Ellers retunere den bare uden at gøre noget
        /// </summary>
        /// <param name="tilfældigtTal"></param>
        /// <param name="gættetTal"></param>
        /// <param name="antalForsøg"></param>
        /// <returns></returns>
        static bool ErGætRigtigt(int tilfældigtTal, int gættetTal, int antalForsøg)
        {
            if (tilfældigtTal == gættetTal)
            {
                Console.Clear();
                Console.Write($"Tilykke, du har vundet spillet med {antalForsøg} gæt tilbage");
                Console.ReadKey();
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Denne metode tjekker om tallet er større eller mindre end det tilfældige tal, og giver besked tilbage om det
        /// </summary>
        /// <param name="tilfældigtTal"></param>
        /// <param name="gættetTal"></param>
        static void ForHøjtEllerLavt(int tilfældigtTal, int gættetTal)
        {
            Console.Clear();
            if (gættetTal < tilfældigtTal)
            {
                Console.Write($"Dit tal {gættetTal}, er mindre end det genererede tal");
            }
            else if (gættetTal > tilfældigtTal)
            {
                Console.Write($"Dit tal {gættetTal}, er større end det genererede tal");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Denne metode omregner temperatur fra Celsius eller Fahrenheit på baggrund af bruger input og omregner det til andre
        /// </summary>
        /// <param name="tempUnit"></param>
        /// <param name="temp"></param>
        static void TempOmregner(int tempUnit, double temp)
        {
            Console.Clear();
            if (tempUnit == 1)
            {
                Console.Write($"Du har indtastet {temp}° Celsius\n\nDet giver\nFahrenheit: {(temp*(9.0/5.0)+32.0)}°\nKelvin: {temp+273.15}°\nRéaumur: {temp*(4.0/5.0)}°");
                Console.ReadKey();
            }
            else if (tempUnit == 2)
            {
                Console.Write($"Du har indtastet {temp}° Fahrenheit\nDet giver\nCelsius: {(temp - 32.0) * (5.0 / 9.0)}°\nKelvin: {((temp-32.0)*(5.0/9.0))+273.15}\nRéaumur: {(temp - 32.0) * (4.0*9.0)}");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Denne metode konvertere et heltal til et decimaltal
        /// </summary>
        /// <param name="helTal"></param>
        /// <returns></returns>
        static double DecConverter(int helTal)
        {
            return ((double)helTal+0.00);
        }

        /// <summary>
        /// Denne metode konvertere et heltal til et hextal via brugeres indtastet heltal og hvilken int base den skal konverteres udfra
        /// </summary>
        /// <param name="helTal"></param>
        /// <returns></returns>
        static string HexConverter(int helTal)
        {
            string hexTal = Convert.ToString(helTal, 16);
            return hexTal;
        }

        /// <summary>
        /// Denne metode konvertere et heltal til et binært tal
        /// </summary>
        /// <param name="helTal"></param>
        /// <returns></returns>
        static string BiConverter(int helTal)
        { 
            string biTal = Convert.ToString(helTal, 2);
            return biTal;
        }
    }
}
