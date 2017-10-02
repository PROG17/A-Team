using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vad heter du?");
            string namn = Console.ReadLine();
            InputController Contoller = new InputController();
            Contoller.StartGame();
            bool runningGame = true;

            while (runningGame)
            {
                
                Console.SetCursorPosition(35,25);
                Console.Write("Var vill du gå?");
                string input = Console.ReadLine().ToLower();
                runningGame= Contoller.inputCheck(input);
            }
            Console.Clear();
            Console.WriteLine("WOHO " +namn+ " du klara det");
            Console.ReadKey();
        }
    }
}
