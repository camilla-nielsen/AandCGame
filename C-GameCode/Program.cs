using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_GameCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* //En lille velkomst samt en kort forklaring til spillet.
            Console.WriteLine("Velkommen til spillet Mini-Hangman");
            Console.WriteLine();
            Console.WriteLine("Der skal gættes et ord. Hvert punktum (.) repræsenterer et bogstav i ordet.");
            Console.WriteLine("Hvis et bogstav gættes korrekt, vil bogstavet erstatte punktummet på den representative plads.");
            Console.WriteLine("Gættes der på et bogstav som ikke indgår i ordet, mistes der et liv. Der er i alt fire liv.");
            Console.WriteLine();
            Console.WriteLine("Tryk Enter for at starte spillet...");
            //For at rydde alt teksten og der derved kun er det "rene" spil på skærmen. 
            Console.ReadLine();
            Console.Clear();
           */
            //Array med liste af samtlige ord der kan spilles i Hangman.
            string[] ord = new string[20] { "Hund", "Solsikke", "Telefon", "Computer", "Plante", "Kamera", "Bukser", "Musik", "Morsekode", "Vindue", "Danmark", "Mercedes", "Høretelefoner", "Regnvejr", "Regnbue", "Google", "Skole", "Bentley", "Programmering", "Slange" };

            Console.WriteLine("Tast et nummer mellem 1 og 20 og tryk Enter.");
            string valgtOrd = Console.ReadLine();
            Console.Clear();

            //Tekst til selve spillet.
            Console.WriteLine("Mini - Hangman");
            Console.WriteLine();
            Console.WriteLine("Indtast et bogstav.");
            Console.WriteLine();

            //Switch som har forudbestemt hvilket ord fra Array der tilhører hvilken case
            switch (valgtOrd)
            {
                case "1":
                    string skjult0 = new string('.', ord[3].Length);
                    Console.WriteLine(skjult0);
                    break;
                case "2":
                    string skjult1 = new string('.', ord[5].Length);
                    Console.WriteLine(skjult1);
                    break;
                case "3":
                    string skjult2 = new string('.', ord[1].Length);
                    Console.WriteLine(skjult2);
                    break;
                case "4":
                    string skjult3 = new string('.', ord[19].Length);
                    Console.WriteLine(skjult3);
                    break;
                case "5":
                    string skjult4 = new string('.', ord[0].Length);
                    Console.WriteLine(skjult4);
                    break;
                case "6":
                    string skjult5 = new string('.', ord[11].Length);
                    Console.WriteLine(skjult5);
                    break;
                case "7":
                    string skjult6 = new string('.', ord[17].Length);
                    Console.WriteLine(skjult6);
                    break;
                case "8":
                    string skjult7 = new string('.', ord[9].Length);
                    Console.WriteLine(skjult7);
                    break;
                case "9":
                    string skjult8 = new string('.', ord[4].Length);
                    Console.WriteLine(skjult8);
                    break;
                case "10":
                    string skjult9 = new string('.', ord[16].Length);
                    Console.WriteLine(skjult9);
                    break;
                case "11":
                    string skjult10 = new string('.', ord[8].Length);
                    Console.WriteLine(skjult10);
                    break;
                case "12":
                    string skjult11 = new string('.', ord[15].Length);
                    Console.WriteLine(skjult11);
                    break;
                case "13":
                    string skjult12 = new string('.', ord[7].Length);
                    Console.WriteLine(skjult12);
                    break;
                case "14":
                    string skjult13 = new string('.', ord[13].Length);
                    Console.WriteLine(skjult13);
                    break;
                case "15":
                    string skjult14 = new string('.', ord[18].Length);
                    Console.WriteLine(skjult14);
                    break;
                case "16":
                    string skjult15 = new string('.', ord[12].Length);
                    Console.WriteLine(skjult15);
                    break;
                case "17":
                    string skjult16 = new string('.', ord[10].Length);
                    Console.WriteLine(skjult16);
                    break;
                case "18":
                    string skjult17 = new string('.', ord[6].Length);
                    Console.WriteLine(skjult17);
                    break;
                case "19":
                    string skjult18 = new string('.', ord[2].Length);
                    Console.WriteLine(skjult18);
                    break;
                case "20":
                    string skjult19 = new string('.', ord[14].Length);
                    Console.WriteLine(skjult19);
                    break;

            }

           // int result = string.Compare(valgtOrd, skrevet ord,true); //Denne for at sammenligne bogstavet med bogstaverne i ordet
           
            
            
            /*Der 
            Random random = new Random();
            string valgtOd = ord[random.Next(ord.Length)];
            Console.WriteLine(valgtOd);*/
        }
    }
}
