using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko
{
    class ShowBoard
    {

        public static void PrintOutBoard(int [,] arr)
        {
            int cellCount = 0;
            
            foreach (var value in arr)
            {
               if ((cellCount % 27) == 0)
                {
                   Console.WriteLine(string.Concat(Enumerable.Repeat("-", 22)));


                }
                if ((cellCount % 3) == 0)
                {
                    Console.Write("|");
                }
                Console.Write(value + " ");
                cellCount++;
                if ((cellCount % 9) == 0)
                {
                    
                    Console.Write("|");
                    Console.WriteLine();
                }
                if (arr.Length == cellCount)
                {
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 22)));
                }
            }
        }
    }
}
