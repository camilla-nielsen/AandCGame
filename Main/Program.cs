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
          Console.WriteLine("Velkommen til");
          Console.WriteLine("A & C Games");
          Console.WriteLine("Tast Enter for at begynde at spille.");
          Console.ReadKey();
          Console.Clear();

          string valg = "";
          while (valg != "1" && valg != "2")
          {
              Console.WriteLine("Vælg mellem disse spil:");
              Console.WriteLine("1. Hangman");
              Console.WriteLine("2. Sten, saks og papir");
              Console.WriteLine();
              Console.WriteLine("Tryk 1 for at spille Hangman og 2 for at spille sten, saks og papir.");
               
                valg = Console.ReadLine();

                if (valg == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Hangman");

                }
                else if (valg == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Sten, saks og papir");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ugyldigt indput.");
                    Console.WriteLine("Tryk 1 for at spille Hangman og 2 for at spille sten, saks og papir.");
                    Console.ReadKey();
                }
          }
        }
    }
}
