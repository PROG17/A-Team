using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Suduko
{
    
    class CalculateMissingNumbers
    {
       
        

        public static void Solv()
        {
             List<int> siffror = new List<int>();
            siffror.Add(1);
            siffror.Add(2);
            siffror.Add(3);
            siffror.Add(4);
            siffror.Add(5);
            siffror.Add(6);
            siffror.Add(7);
            siffror.Add(8);
            siffror.Add(9);

            int count = 0;

            try
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (row < 3 && col < 3)
                        {
                            Console.Write(Program.sucodoArray[row, col] + "siffra");
                        }
                        if (Program.sucodoArray[row, col] == 0)
                        {
                       

                            for (int i = 0; i < siffror.Count; i++)
                            {

                                if (siffror[i] == Program.sucodoArray[row, col])
                                {
                                    siffror.RemoveAt(i);
                                }
                            }

                            for (int rows = 0; rows < 9; rows++)
                            {


                             //   if (Program.sucodoArray[rows, col] == 0)
                             //   {
                             //       Program.sucodoArray[rows, col] = 1;
                             //       count++;
                             //   }
                             //
                             //   for (int i = 0; i < siffror.Count; i++)
                             //   {
                             //
                             //       if (siffror[i] == Program.sucodoArray[rows, col])
                             //       {
                             //           siffror.RemoveAt(i);
                             //       }
                             //   }



                            }
                           
                            foreach (var siffra in siffror)
                            {
                                Console.Write(siffra);
                            }
                            Console.WriteLine();
                            siffror.Clear();
                            siffror.Add(1);
                            siffror.Add(2);
                            siffror.Add(3);
                            siffror.Add(4);
                            siffror.Add(5);
                            siffror.Add(6);
                            siffror.Add(7);
                            siffror.Add(8);
                            siffror.Add(9);

                            if (siffror.Count == 1)
                            {
                                Program.sucodoArray[row, col] = siffror[0];
                            }

                        }
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
