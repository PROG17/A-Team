using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko
{
    class CreateBoard
    {
       // public string suducoInput { get; set; }
        
            

        public static void SortToArray(string input)
        {
            int count = 0;
            try
            {               
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {


                        
                            Program.sucodoArray[row, col] = (int) char.GetNumericValue(input[count]);
                            count++;
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
