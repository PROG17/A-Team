using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Suduko
{

    class CalculateMissingNumbers
    {

        public static List<int> siffror = new List<int>();

        public static void AddNumbersToSiffrorArray()
        {
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
        }
        public static void Solv()
        {
            try
            {
                int dotCount = 0;
                bool test = true;
                int count = 0;
                bool runProgram = true;
                //Håller koll på vilken rad vi är i arrayen
                while (runProgram)
                {
                    runProgram = false;

                    for (int row = 0; row < 9; row++)
                    {
                        //håller koll på cilken col vi är på
                        for (int col = 0; col < 9; col++)
                        {
                            AddNumbersToSiffrorArray();
                            //Charlie was here.

                            // Kollar om det är en nolla på cell platsen 
                            if (Program.sucodoArray[row, col] == 0)

                            {
                                test = true;
                                //kollar varje cell i raden      
                                for (int col2 = 0; col2 < 9; col2++)
                                {

                                    if (siffror.Contains(Program.sucodoArray[row, col2]))
                                    {
                                        siffror.Remove(Program.sucodoArray[row, col2]);
                                    }


                                }
                                //kollar varje col cell
                                for (int row2 = 0; row2 < 9; row2++)
                                {
                                    if (siffror.Contains(Program.sucodoArray[row2, col]))
                                    {
                                        siffror.Remove(Program.sucodoArray[row2, col]);
                                    }
                                }
                                //kollar boxen col 
                                while (test)
                                {
                                    //sätter rowCheck och colCheck till där man är
                                    int rowCheck = row, colCheck = col;
                                    //sätter alltid rowMin och colMin till row för det är det lägsta om det är %3
                                    int rowMin = row, rowMax = 0, colMin = col, colMax = 0;
                                    //lägsta rad
                                    // kollar lägsta rowmin om inte det redan ä det
                                    while ((rowCheck % 3) != 0)
                                    {

                                        rowCheck--;
                                        rowMin = rowCheck;
                                    }
                                    //högsta rad
                                    //kollar högsta row i boxen (för att starta den så startar den från lägsta som vi räkna ut innan +1 annars så är den automatiskt 0;
                                    while (((rowCheck + 1) % 3) != 0)
                                    {


                                        rowCheck++;
                                        rowMax = rowCheck;
                                    }
                                    //lägsta Col
                                    while ((colCheck % 3) != 0)
                                    {

                                        colCheck--;
                                        colMin = colCheck;
                                    }

                                    //högsta col
                                    while (((colCheck + 1) % 3) != 0)
                                    {

                                        colCheck++;
                                        colMax = colCheck;
                                    }

                                    //Håller koll på vilken rad vi är i arrayen
                                    for (int y = rowMin; y < (rowMax + 1); y++)
                                    {
                                        //håller koll på cilken col vi är på
                                        for (int x = colMin; x < (colMax + 1); x++)
                                        {
                                            //kollar om siffran finns i sifror
                                            if (siffror.Contains(Program.sucodoArray[y, x]))
                                            {
                                                siffror.Remove(Program.sucodoArray[y, x]);
                                            }
                                        }
                                    }
                                    //Kollar om det är en kvar i siffror för då är det den.
                                    if (siffror.Count == 1)
                                    {
                                        Program.sucodoArray[row, col] = siffror[0];
                                        runProgram = true;
                                    }
                                    Console.Clear();

                                    //För att skriva ut på skärmen steg för steg
                                    test = false;
                                    Console.WriteLine("Siffra Saknas i rad:" + row + " col:" + col + "   Boxen är RowMin=" + rowMin + "  RowMax=" + rowMax + "  ColMin=" + colMin + "  ColMax=" + colMax);
                                    Console.Write("Värdena som kan vara i=");

                                    foreach (var value in siffror)
                                    {
                                        Console.Write(value + ",");
                                    }
                                    Console.WriteLine();
                                    ShowBoard.PrintOutBoard(Program.sucodoArray);
                                    Console.WriteLine("Solving" + string.Concat(Enumerable.Repeat(".", dotCount)));
                                    dotCount++;
                                    if (dotCount > 5)
                                    {
                                        dotCount = 0;
                                    }
                                    Thread.Sleep(50);

                                    //    Console.ReadLine();
                                    count++;
                                    // Slut för att visa på skärmen



                                }
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

