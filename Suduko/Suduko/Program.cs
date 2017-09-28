using System;

namespace SudokuMarran
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Sudoku("000050000906000307000409000010000050200607001040000090000701000709000206000030000");
            //var game = new Sudoku("003020600900305001001806400008102900700000008006708200002609500800203009005010300");
            game.Solve();
            if (game.IsGameSolved)
            {
                Console.WriteLine(game.BoardAsText);
            }
            else
            {
                Console.WriteLine("Kunde inte lösa spelet");
            }
            Console.ReadLine();
        }
    }
}
