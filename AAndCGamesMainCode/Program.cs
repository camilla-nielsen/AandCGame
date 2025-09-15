using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAndCGamesMainCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til");
            Console.WriteLine("A & C Games");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Vælg mellem disse spil:");
            Console.WriteLine("1. Hangman");
            Console.WriteLine("2. Sten, saks og papir");
            Console.WriteLine();
            Console.WriteLine("Tryk 1 for at spille Hangman og 2 for at spille sten, saks og papir.");

            string valg = Console.ReadLine();
            

            if (valg == "1")
            {
                Console.WriteLine("Hangman");
            }
            
            if (valg == "2")
            {
                Console.WriteLine("Sten, saks og papir");
            }
            else
            {
                Console.WriteLine("Tryk 1 for at spille Hangman og 2 for at spille sten, saks og papir.");
            }
        }
    }
}
