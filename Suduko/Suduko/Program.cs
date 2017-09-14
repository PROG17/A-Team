using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko
{
    class Program
    {
        //skapar en ny instans av Createboard
        public static CreateBoard test = new CreateBoard();
        public static int[,] sucodoArray = new int[9, 9];
        static void Main(string[] args)
        {
            string sucodoNumbers = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
            CreateBoard.SortToArray(sucodoNumbers);
            ShowBoard.PrintOutBoard(sucodoArray);
            CalculateMissingNumbers.Solv();
            ShowBoard.PrintOutBoard(sucodoArray);
            Console.ReadLine();
            
            
        }
    }
}
