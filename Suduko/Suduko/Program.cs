using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Suduko
{
    class Program
    {
        // 2d arrayen som vi sparar sukodon i 
        public static int[,] sucodoArray = new int[9, 9];
        static void Main(string[] args)
        {

            //Strängen med sukudon vi ska läsa
            string sucodoNumbers = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
            // Gör om strängen till en 2d array
            CreateBoard.SortToArray(sucodoNumbers);
            //skriver ut sukodon från arrayen som den ska visas
            ShowBoard.PrintOutBoard(sucodoArray);
            // Försöker att byta ut 0or i arrayen till rätt nummer 
            CalculateMissingNumbers.Solv();
            Console.Clear();
            ShowBoard.PrintOutBoard(sucodoArray);
            Console.WriteLine("Solved!");


            Console.ReadLine();
        }
    }
}
