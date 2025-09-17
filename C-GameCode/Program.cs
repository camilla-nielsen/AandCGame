using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C_GameCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Hele denne funktion er skrevet af Camilla Nielsen. SIBDAT25
            Formålet med koden er, at få et spil mini-Hangman op og køre. Koden kører i loop, og stopper efter spilleren
            har tabt eller vundet, og spilleren får derefter valget om at starte et nyt spil eller afslutte(a), og
            vender derefter retur til hovedmenuen.*/

            //En lille velkomst samt en kort forklaring til spillet,med en blå baggrund og hvid skrift.
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Velkommen til spillet Mini-Hangman");
            Console.WriteLine();
            Console.WriteLine("Der skal gættes et ord. Hvert punktum (.) repræsenterer et bogstav i ordet.");
            Console.WriteLine("Hvis et bogstav gættes korrekt, vil bogstavet erstatte punktummet på den representative plads.");
            Console.WriteLine("Gættes der på et bogstav som ikke indgår i ordet, mistes der et liv. Der er i alt fire liv.");
            Console.WriteLine();
            Console.WriteLine("Tryk Enter for at starte spillet...");
            Console.ReadKey();

            //Boolsk værdi, der muliggøre en while loop der kører, så længe at spilIgen er true.
            bool spilIgen = true;

            //While loop, som er gældende, så længe at "bool spilIgen" er true.
            while (spilIgen)
            {

                  //Clear for at rydde alt tekst og der derved kun er det "rene" spil på skærmen, samt en sort baggrund med hvid skrift. 
                  Console.BackgroundColor = ConsoleColor.Black;
                  Console.Clear();
                  Console.ForegroundColor = ConsoleColor.White;

                //Tekst der vises under selve spillet.
                Console.WriteLine("Mini - Hangman");
                Console.WriteLine();
                Console.WriteLine("Indtast et bogstav:");
                Console.WriteLine();            

                //Da min funktion har to variabler, hentes de derfra, således begge er gældende. 
                var (valgtOrd, skjult) = SelectWord();

                //Skriver ordet der skal gættes.
                Console.WriteLine(skjult);

                //String som holder spillerens svar.
                string svar = "";

                //Variabel der giver spilleren fire liv.
                int liv = 3;

                //Do while der sørger for at spillet kører, indtil at spilleren enten taber eller vinder.
                do
                {
                    //Do while der kører så spilleren kan gætte flere bogstaver. 
                    do
                    {                   
                        //String svar, hvor spilleren kan taste sit bogstav.
                        svar = Console.ReadLine();
                    } while (string.IsNullOrEmpty(svar));                    

                    //Array der styrre bogstaverne i det skjutle ord, for at de kan vises (char)
                    char[] skjultArray = skjult.ToCharArray();

                    //Bool der tracker om det gættede bogstav er i ordet
                    bool found = false; 

                    //Sammenligner det tastede bogstav fra spilleren med valgtOrd
                    for (int i = 0; i < valgtOrd.Length; i++)
                    {
                        //"if" karakter(char) for "valgtOrd" og "svar" er ens, bruges denne kodeblok. Begge ord er sat til ToLower, for at de er sammenlignelige
                        if (char.ToLower(valgtOrd[i]) == char.ToLower(svar[0]))
                        {
                            //Viser bogstavet i det valgte ord
                            skjultArray[i] = valgtOrd[i];

                            //Bool som fortæller at karakteren(char) i "svar" er i ordet "valgtOrd". Derved true.
                            found = true;
                        }
                    }
                    //Hvis bogstav er korrekt, opdateres "string skjult" med bogstavet
                    Console.Clear();

                    //Indtroduktion til spilleren, under hele spillet.
                    Console.WriteLine("Mini - Hangman");
                    Console.WriteLine();
                    Console.WriteLine("Indtast et bogstav:");

                    skjult = new string(skjultArray);
                    Console.WriteLine(skjult);

                    //Hvis(if) det tastede bogstav ikke findes(!found) i ordet, kommer denne boks i spil. 
                    if (!found)
                    {
                        //Decrement som sørger for, at spilleren mister et liv, hver gang der gættes forkert.
                        liv--;

                        //Der angives ud fra "int liv", hvor mange liv der er tilbage.
                        Console.WriteLine($"Forkert gæt. Du har {liv} liv tilbage.");

                        //Hvis liv = 0, er spillet slut, og spilleren har tabt.
                        if (liv == 0)
                        {
                            //En rød skærm med hvid skrift.
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;

                            //Når spilleren har tabt, kommer følgende besked frem.
                            Console.WriteLine();
                            Console.WriteLine("Du har tabt! :'( ");
                            Console.WriteLine("Ordet du skulle gætte var: " + valgtOrd);
                            Console.WriteLine();
                            Console.WriteLine("For at spille igen, tryk Enter, eller tryk a, for at vende tilbage til menuen.");

                            //Spilleren kan nu taste, alt efter om der skal spilles igen eller ej.
                            var retur = Console.ReadLine();

                            //Hvis spilleren har tastet "a" i "var retur", afsluttes spillet og spilleren kommer retur til menuen.
                            spilIgen = retur != "a";
                            break;
                        }
                    }
                    //Forsætter indtil alle bogstaver er gættet, altså så længe at "string skjult" indholder punktummer.
                } while (skjult.Contains("."));

                //Hvis(if) alle bogstaver er gættet, er alle punktummer væk, så gælder dette ikke(!skjult(Contains(".")) og spillet er derfor vundet.
                if (!skjult.Contains("."))
                {
                    //En grøn skærm, med sort skrift.
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;

                    //Når spilleren har gættet ordet, kommer følgende besked frem
                    Console.WriteLine();
                    Console.WriteLine("Tillykke! :-)");
                    Console.WriteLine("Du har gættet ordet og har dermed vundet!");
                    Console.WriteLine();
                    Console.WriteLine("For at spille igen, tryk Enter, eller tryk a, for at vende tilbage til menuen.");

                    //Spilleren kan nu taste om der skal spilles igen eller ej.
                    var retur = Console.ReadLine();

                    //Hvis spilleren har tastet "a" i "var retur", afsluttes spillet og spilleren kommer retur til menuen.
                    spilIgen = retur != "a";
                }
            }
        }
        /// <summary>
        /// Funktion som udvælger hvilket ord, som spilleren skal gætte, samt gør ordet skjult til spillet.
        /// </summary>
        /// <returns>Det valgtOrd og det valgteOrd skjult</returns>
        static (string valgtOrd, string skjult) SelectWord()
        {
            //Array med liste af samtlige ord der kan spilles i Hangman.
            string[] ord = new string[20] { "Hund", "Solsikke", "Telefon", "Computer", "Plante", "Kamera", "Bukser", "Musik", "Morsekode", "Vindue", "Danmark", "Mercedes", "Høretelefoner", "Regnvejr", "Regnbue", "Google", "Skole", "Bentley", "Programmering", "Slange" };

            //Random oprettes, hvor der trækkes et random ord fra ordArray til spillet, som laves til en string.
            Random random = new Random();
            string valgtOrd = ord[random.Next(ord.Length)];

            // String skjult, skifter bogstaverne i valgtOrd ud med punktummer, så det derved synes skjult for spilleren.
            string skjult = new string('.', valgtOrd.Length);
            return (valgtOrd, skjult);
        }
    }
}
