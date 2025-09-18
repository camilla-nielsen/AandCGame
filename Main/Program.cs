using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* SIBDAT25
             Denne funktion er skrevet af Anna Vognstoft og Camilla Nielsen. 
             Formålet med koden er, at få en velkomst, og når der trykkes Enter, så kommer man videre til selve
             spilmenuen. Fra spilmenuen kan der træffes to valg - enten 1. Hangman eller 2. Sten, saks og papir.
             Når spilleren har truffet sit valg, så ryger man videre til den pågældende funktion, hvor spillet kan spilles.*/

            //Den indledende velkomst med en mørke grå baggrund og hvid skrift.
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Velkommen til");
            Console.WriteLine("A & C Games");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tast Enter for at begynde at spille.");
            Console.ReadKey();
            Console.Clear();

            /*"Static void Menu" funktionen kaldes, dette for at undgå at når spilleren har spillet et spil, at velkomstskærmen 
               kommer igen, men at det kun er selve spille-menuen som dukker op.*/
            Menu();
        }
        /// <summary>
        /// Menu funktion, som tillader os at vende retur til spilmenuen, efter endt spil. Skrevet af Anna Vognstoft og Camilla Nielsen.
        /// </summary>
        static void Menu()
        {
            //String valg, som giver spilleren mulighed for at navigere mellem de to spil.
            string valg = "";

            //Variabel der giver spilleren fire forsøg til at taste 1 eller 2, for at komme i spil.
            int forsog = 3;

            //While loop, som kører, indtil at spilleren har tastet enten 1 eller 2, for at tilgå det pågældende spil.
            while (valg != "1" && valg != "2")
            {
                //En introduktion til spilleren, i forhold til, hvilke taster der er relevante, med en sort baggrund og hvid skrift.
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Spil-menu:");
                Console.WriteLine("1. Hangman");
                Console.WriteLine("2. Sten, saks og papir");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Tryk 1 for at spille Hangman og 2 for at spille sten, saks og papir.");
                Console.WriteLine("Tast q for at lukke programmet.");

                //Koden læser spillerens tast, både med stort og lille bogstav.
                valg = Console.ReadLine().ToLower();

                //If-betingelse som leder spilleren til "SpilHangman" funktionen, hvis spilleren har tastet 1.
                if (valg == "1")
                {
                    //SpilHangman funktion tilgås.
                    SpilHangman();
                }

                //Else if-betingelse som leder spilleren til "StenSaksPapir" funktionen, hvis spilleren har tastet 2.
                else if (valg == "2")
                {
                    //SpilSSP funktion tilgås.
                    SpilSSP();
                }

                //Else if-betingelse som lukker programmet hvis spilleren taster q.
                else if (valg == "q")
                {
                    Environment.Exit(0);
                }

                //Else-betingelse som fortæller spilleren at deres input er ugyldigt, og de skal taste enten 1 eller 2.
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ugyldigt indput.");
                    Console.WriteLine("Tryk 1 for at spille Hangman og 2 for at spille sten, saks og papir.");
                    Console.ReadKey();

                    //Decrement som sørger for, at spilleren mister et forsøg, hver gang der tastes forkert.
                    forsog--;

                    //If-betingelse som kører, hvis spilleren har opbrugt sine forsøg på at komme ind i spille, og programmet sluttes.
                    if (forsog == 0)
                    {
                        //Skærm med en afsluttende besked, med rød skærm og hvid skrift.
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Du har opbrugt dine forsøg, du skal vist ikke spille i dag alligevel...");

                        //Programmet lukkes ned.
                        break;
                    }
                }
            }


        }
        /// <summary>
        /// Skrevet af Camilla. Indholder koden til spillet hangman.
        /// </summary>
        static void SpilHangman()
        {
            /*Hele denne funktion er skrevet af Camilla Nielsen. SIBDAT25
              Formålet med koden er, at få et spil mini-Hangman op og køre. Koden kører i loop, og stopper efter spilleren
              har tabt eller vundet, og spilleren får derefter valget om at starte et nyt spil eller afslutte(a), og
              vender derefter retur til hovedmenuen.*/

            //En lille velkomst, samt en kort forklaring til spillet,med en blå baggrund og hvid skrift.
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
                Console.WriteLine("Indtast et bogstav og tryk Enter:");
                Console.WriteLine();

                //Da min funktion har to variabler, hentes de derfra, således begge er gældende. 
                var (valgtOrd, skjult) = SelectWord();

                //Udskriver ordet der skal gættes, til en start med punktummer.
                Console.WriteLine(skjult);

                //String som holder spillerens svar.
                string svar = "";

                //Variabel der giver spilleren fire liv.
                int liv = 3;

                //Do while der sørger for at spillet kører, indtil at spilleren enten taber eller vinder.
                do
                {
                    //Do while loop som giver spilleren mulighed for at taste et ny bogstav efter hver runde. 
                    do
                    {
                        //String svar, hvor spilleren kan taste sit bogstav.
                        svar = Console.ReadLine();

                        //Betingelse der gør at loop stopper, så snart at "svar" har et eller flere tegn, altså når spilleren har indtastet et tegn.
                    } while (string.IsNullOrEmpty(svar));

                    //Array der konventerer en string til tegn(char), så det spillede ords bogstaver deles ud på et Array.
                    char[] skjultArray = skjult.ToCharArray();

                    //Bool der indikerer at det der ledes efter er false, altså ikke fundet endnu.
                    bool found = false;

                    //For-loop som gennemgår valgtOrds bogstaver
                    for (int i = 0; i < valgtOrd.Length; i++)
                    {
                        //En if betingelse, som gennemgår valgtOrds bogstaver [i], med det indstastede svar [0], begge med ToLower, for at undgå fejl. Er de ens, bruges scopet.
                        if (char.ToLower(valgtOrd[i]) == char.ToLower(svar[0]))
                        {
                            //Via skjultArray, findes pladsen af det korrekt gættede bogstav i valgtOrd Array.
                            skjultArray[i] = valgtOrd[i];

                            //Bool melde true, altså bogstavet findes i ordet. 
                            found = true;
                        }
                    }
                    //Hvis bogstav er korrekt, opdateres "string skjult" med bogstavet
                    Console.Clear();

                    //Indtroduktion til spilleren, under hele spillet.
                    Console.WriteLine("Mini - Hangman");
                    Console.WriteLine();
                    Console.WriteLine("Indtast et bogstav:");

                    //String skjult opdateres via skjultArray, hvis denne er blevet opdateret i for-loop.
                    skjult = new string(skjultArray);
                    Console.WriteLine(skjult);

                    //En if-betingelse for hvis det gættede bogstav ikke findes i ordet. 
                    if (!found)
                    {
                        //Decrement som sørger for, at spilleren får fratrukket et liv, hver gang der gættes forkert.
                        liv--;

                        //Teskt det ud fra "int liv" angiver, hvor mange liv spilleren har tilbage.
                        Console.WriteLine($"Forkert gæt. Du har {liv} liv tilbage.");

                        //En if-betingelse som bruges i tilfælde af, at spilleren har opbrugt sine liv.
                        if (liv == 0)
                        {
                            //En rød skærm med hvid skrift.
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;

                            //Når spilleren har tabt, kommer følgende besked frem, samt en afsløring af ordet der skulle gættes.
                            Console.WriteLine("Du har tabt! :'( ");
                            Console.WriteLine("Ordet du skulle gætte var: " + valgtOrd);
                            Console.WriteLine();
                            Console.WriteLine("For at spille igen, tryk Enter, eller tryk a, for at vende tilbage til menuen.");

                            //Spilleren kan nu taste, alt efter om der skal spilles igen eller ej.
                            string taber = Console.ReadLine().ToLower();

                            //En if-betingelse hvis spilleren taster "a", da de så kommer retur til menuen.
                            if (taber == "a")
                            {
                                //Skærmen rydes og "static void Menu" kaldes, og spilleren kommer retur til menuen.
                                Console.Clear();
                                Menu();
                            }
                        }
                    }
                    //Forsætter indtil alle bogstaver er gættet, altså så længe at "string skjult" indholder punktummer.
                } while (skjult.Contains("."));

                //En if-betingelse hvis spilleren har gættet allt ord, da vil "skjult" ikke længere indeholde punktummer.
                if (!skjult.Contains("."))
                {
                    //En grøn skærm, med sort skrift.
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;

                    //Når spilleren har gættet ordet, kommer følgende besked frem                    
                    Console.WriteLine("Tillykke! :-)");
                    Console.WriteLine("Du har gættet ordet og har dermed vundet!");
                    Console.WriteLine();
                    Console.WriteLine("For at spille igen, tryk Enter, eller tryk a, for at vende tilbage til menuen.");

                    //Spilleren kan nu taste, alt efter om der skal spilles igen eller ej.
                    string vinder = Console.ReadLine().ToLower();

                    //En if-betingelse hvis spilleren taster "a", da de så kommer retur til menuen.
                    if (vinder == "a")
                    {
                        //Skærmen rydes og "static void Menu" kaldes, og spilleren kommer retur til menuen.
                        Console.Clear();
                        Menu();

                    }
                }
            }
        }
        /// <summary>
        /// Skrevet af Camilla. Funktion som udvælger hvilket ord, som spilleren skal gætte, samt gør ordet skjult til spillet. 
        /// </summary>
        /// <returns>Det valgtOrd og det valgteOrd skjult</returns>
        private static (string valgtOrd, string skjult) SelectWord()
        {
            //Array med liste af samtlige ord der kan spilles i Hangman.
            string[] ord = new string[20] { "Hund", "Solsikke", "Telefon", "Computer", "Plante", "Kamera", "Bukser", "Musik", "Morsekode", "Vindue", "Danmark", "Mercedes", "Høretelefoner", "Regnvejr", "Regnbue", "Google", "Skole", "Bentley", "Programmering", "Slange" };

            //Random oprettes, hvor der trækkes et random ord fra "ordArray" til spillet, som laves til en string.
            Random random = new Random();
            string valgtOrd = ord[random.Next(ord.Length)];

            // String skjult, skifter bogstaverne i "valgtOrd" ud med punktummer, så det derved er skjult for spilleren.
            string skjult = new string('.', valgtOrd.Length);
            return (valgtOrd, skjult);
        }
        /// <summary>
        /// Kodet af Anna. Funktion er hele Sten, saks eller papir-spillet. 
        /// </summary>
        static void SpilSSP()
        {
            Console.Clear();
            // Byder velkommen 
            Console.WriteLine("Velkommen til spillet STEN, SAKS eller PAPIR");
            Console.WriteLine("Tryk på enter og lad os spille et spil");
            // Clear skærmen så spillet kan spilles
            Console.ReadKey();
            Console.Clear();
            // Kalder variablerne her for overblik
            string spillerVaaben = "";
            int compScore = 0;
            int spillerScore = 0;

            // En uendelig loop, der kører til break; (når spiller taster 'a')
            while (true)
            {
                // Sørger for, at spillet 'sletter' før en ny runde, så gamle tidligere runder ikke ses
                Console.Clear();
                // Scoreboard øverst (Er sat ind to gange i loopet, så man hele tiden kan se stillingen med disse to int variabler 
                Console.WriteLine($"Her er SPILLETS SCOREBOARD: Computeren har {compScore} point. Du har {spillerScore} point");
                Console.WriteLine();
                Console.WriteLine("Du skal taste 1 for sten, 2 for saks eller 3 for papir. Ønsker du at afslutte spillet - tast 'a'");

                // Sørger for at input altid bliver konverteret til små bogstaver ved output, så svar kan sammenlignes med computerns svar
                string inputFraSpiller = Console.ReadLine().ToLower();
                // Her sørger jeg for, at spillet (loopet) kan afsluttes, så det ikke bliver et evighedsloop
                if (inputFraSpiller == "a")
                {
                    //En sluthilsen med et slutresultat
                    Console.Clear();
                    Console.WriteLine("Tak for spillet!");
                    Console.WriteLine($"Computeren har {compScore} point.Du har {spillerScore} point");

                    if (compScore == spillerScore)
                    { Console.WriteLine("Spillet endte uafgjort. Tast enter for menu."); }

                    else if (compScore < spillerScore)
                    { Console.WriteLine("Tillykke! Du vandt spillet. Tast enter for menu."); }

                    else if (compScore > spillerScore)     
                    { Console.WriteLine("Computeren vandt spillet. Bedre held næste gang. Tast enter for menu."); }

                    Console.ReadKey();
                    //Skærmen rydes og "static void Menu" kaldes, og spilleren kommer retur til menuen.
                    Console.Clear();
                        Menu();                
                   
                }

                // Jeg har lavet et array, der har et index med tre ord, som bliver output 
                string[] brugerVaaben = { "sten", "saks", "papir" };
                // Her konverteres string til int og tjekker, at input er 1-3
                if (int.TryParse(inputFraSpiller, out int talValg) && talValg >= 1 && talValg <= 3)
                {
                    // Her forbindes indexet med tal-input og spillerens input, så output bliver ord fra indexet. Minus 1 sørger for, at korrekt input til index er 1-3.
                    spillerVaaben = brugerVaaben[talValg - 1];
                }



                Console.Clear();
                // True hvis spiller indtaster korrekt tal og får følgende output 
                if (spillerVaaben == "sten" || spillerVaaben == "saks" || spillerVaaben == "papir")
                {
                    //Et array bruges til random generator, så computeren vælger et vilkårligt ord fra indexet for hver runde
                    string[] vaaben = { "sten", "saks", "papir" };
                    Random rnd = new Random();
                    string compVaaben = vaaben[rnd.Next(0, vaaben.Length)];

                    //Sørger for at scoreboardet bliver hængende efter endt runde - før ny runde
                    Console.Clear();
                    Console.WriteLine($"Her er SPILLETS SCOREBOARD: Computeren har {compScore} point. Du har {spillerScore} point");
                    Console.WriteLine();

                    //Her afsløres computerens og spillerens valg af våben med string interpolation
                    Console.WriteLine($"Du har valgt: {spillerVaaben}");
                    Console.WriteLine($"Computeren valgte: {compVaaben}");

                    //Her afgøres rundens resultat og scoreboard opdateres
                    //Her kaldes funktion   
                    string rundeVinder = FindVinder(compVaaben, spillerVaaben);
                    Console.WriteLine(rundeVinder);

                    //Her kaldes int funktionerne 
                    compScore = BeregnComputerPoint(compScore, rundeVinder);
                    spillerScore = BeregnSpillerPoint(spillerScore, rundeVinder);

                    Console.WriteLine("Tast enter for at spille igen");
                    Console.ReadKey();
                }
                //Ved fejltastning sker følgende:
                else if (spillerVaaben != "a" && inputFraSpiller != "1" && inputFraSpiller != "2" && inputFraSpiller != "3")
                {
                    Console.WriteLine("Du tastede forkert. Husk at du kun skal taste '1', '2' eller '3' for at spille og 'a' for at afslutte. Tast enter og prøv igen.");
                    Console.ReadKey();
                }

            }

            

        }
        /// <summary>
        /// Skrevet af Anna. Funktion returnerer en string, der fortæller, hvem der vandt runden
        /// </summary>
        /// <param name="compVaaben"></param>
        /// <param name="spillerVaaben"></param>
        /// <returns>Resultatet af runden i form af string</returns>
        static string FindVinder(string compVaaben, string spillerVaaben)
        {
            if (compVaaben == spillerVaaben)
            {
                return "Uafgjort!";
            }
            if ((spillerVaaben == "sten" && compVaaben == "saks") || (spillerVaaben == "papir" && compVaaben == "sten") || (spillerVaaben == "saks" && compVaaben == "papir"))
            {
                return "Yay. Du vinder over computeren";
            }
            else
            {
                return "Desværre. Computeren vinder";
            }
        }
        /// <summary>
        /// Skrevet af Anna. Int funktion returnerer computerpoint til scoreboard
        /// </summary>
        /// <param name="compScore"></param>
        /// <param name="rundeVinder"></param>
        /// <returns>computerens point</returns>
        static int BeregnComputerPoint(int compScore, string rundeVinder)
        {
            if (rundeVinder == "Desværre. Computeren vinder")
            {
                return (compScore + 1);
            }
            else
            { return compScore; }
        }
        /// <summary>
        /// Skrevet af Anna. int funktion returnerer spillerpoint til scoreboard
        /// </summary>
        /// <param name="spillerScore"></param>
        /// <param name="rundeVinder"></param>
        /// <returns>spillerens score</returns>
        static int BeregnSpillerPoint(int spillerScore, string rundeVinder)
        {
            if (rundeVinder == "Yay. Du vinder over computeren")
            {
                return (spillerScore + 1);
            }
            else
            { return spillerScore; }

        }
    }
}