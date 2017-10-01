using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class MapHandler
    {
       
       
        ///<summary>
        ///Information om vareiablar
        ///</summary>
        ///<remarks>
        /// int[,] map = new int[10, 10]; Hur stor kartan är men ska hämtas från rum sen
        /// bool[] canMoveSides = new bool[4]; Hanterar vilka håll man får gå åt [0]norr [1]söder [2]väster [3]öster baserat på true false
        /// yPosScreen xPosScreen är för att skriva ut kartan på rätt plats (ska ändras)
        /// YposMap xPosMap är för att komma ihåg var man är
        ///</remarks>

      //  int[] mapCord = new[] { 0, 0 };

        //Tillfällig variablar för att hålla koll var man är och vaf vi ska skriva ut X
       private int yPosScreen = 1;
       private int xPosScreen = 75;
       

        ///<summary>
        ///MapMovement
        ///</summary>
        ///<remarks>
        /// yMapSize o xMapSize hämtar hur stor kartan är från arrayen
        /// canMoveSides testar om man går utanför arrayen (ska implementera canMove sides)
        /// if satser sen som testar vilket håll man går och jämnför med canMoveSides
        ///</remarks>
        public  int[] MapMovement(string input,int [,]map, int[] mapCord, RoomHandler rooms)
        {
            
            bool[] canMoveSides = new bool[4];
            canMoveSides = TryMovement(mapCord, map,rooms);
            int [] exitsWeHave = rooms.ExitsThereIsInRoom(mapCord);
            rooms.PopulateDoorList();
            
            Console.Clear();

            string[] doors = rooms.GetDoorsNameForRoom(mapCord);
            if (input == "norr" && canMoveSides[0]  )
            {
                
                
                if (rooms.CanweWalkThru(doors[0]))
                {
                    yPosScreen--;
                    mapCord[0]--;
                }
                else
                {
                    Console.SetCursorPosition(20, 20);
                   int index = rooms.FindIdexDoorName(doors[0]);
                    Console.WriteLine(rooms.doors[index].description);
                }
            }
            else if (input == "söder" && canMoveSides[1] )
            {
              if (rooms.CanweWalkThru(doors[1]))
                {
                    yPosScreen++;
                    mapCord[0]++;
                }
                else
                {
                    Console.SetCursorPosition(20, 20);

                    int index = rooms.FindIdexDoorName(doors[1]);
                    index --;
                    Console.WriteLine(rooms.doors[index].description);
                }
            }
            else if (input == "väster" && canMoveSides[2])
            {
                if (rooms.CanweWalkThru(doors[2]))
                {
                    xPosScreen--;
                    mapCord[1]--;
                }
                else
                {
                    Console.SetCursorPosition(20, 20);
                    int index = rooms.FindIdexDoorName(doors[2]);
                    Console.WriteLine(rooms.doors[index].description);
                }
            }
            else if (input == "öster" && canMoveSides[3] )
            {
                if (rooms.CanweWalkThru(doors[3]))
                {
                    xPosScreen++;
                    mapCord[1]++;
                }
                else
                {
                    Console.SetCursorPosition(20, 20);
                    int index = rooms.FindIdexDoorName(doors[3]);
                    Console.WriteLine(rooms.doors[index].description);
                }
            }
            else if (input == "start")
            {
                
            }
            else
            {
                Console.SetCursorPosition(0, 2);
                Console.Write("Du kunde inte gå dit");
            }
         
            input = "";
            ///<summary>
            ///Enkel sätt att skriva ut var man är (ska ha egen metod sen)(WIP)
            ///</summary>
            ///<remarks>
            /// Här skriver vi ut ett X var vi är och cords
            ///</remarks>
            
            return mapCord;
        }

        public void TestForDoors(int []mapCords)
        {
            
        }
        ///<summary>
        ///TryMovement (WIP)
        ///</summary>
        ///<remarks>
        /// TryMovement testar så man inte går utanför arrayen genom att testa movement först innan man gör den
        ///</remarks>
        public bool[] TryMovement(int []mapCordToTest ,int[,]map, RoomHandler rooms)
        {
            rooms.PopulateDoorList();
            bool[] canMoveSides = new bool[4];
            //upp
            
            if ((mapCordToTest[0] - 1) >= 0)
            {
                
                canMoveSides[0] = true;
            }
            else
            {
                canMoveSides[0] = false;
            }
            //ner
            if ((mapCordToTest[0] + 1) < map.GetLength(0))
            {
                canMoveSides[1] = true;
            }
            else
            {
                canMoveSides[1] = false;
            }

            //Vänster
            if ((mapCordToTest[1] - 1) >= 0)
            {
                canMoveSides[2] = true;
            }
            else
            {
                canMoveSides[2] = false;
            }
            //Höger
            if ((mapCordToTest[1] + 1) <map.GetLength(1))
            {
                canMoveSides[3] = true;
            }
            else
            {
                canMoveSides[3] = false;
            }
            return canMoveSides;
        }

        public void ShowPossition( int[] mapCord)
        {
          
  
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Din Possition");
            Console.SetCursorPosition(100, 1);
            Console.Write("YPos:" + mapCord[0] + " XPos:" + mapCord[1]);
            Console.SetCursorPosition(100, 2);
            Console.WriteLine("Karta");
            Console.SetCursorPosition(100, 3);
            Console.SetCursorPosition(mapCord[0], mapCord[1]);
            Console.SetCursorPosition(100, 3);
            Console.WriteLine("---");
            Console.SetCursorPosition(100, 4);
            Console.WriteLine("---");
            Console.SetCursorPosition(100, 5);
            Console.WriteLine("---");
            
            Console.SetCursorPosition(100 + mapCord[1], 3 + mapCord[0]);
            Console.Write("x");
            Console.SetCursorPosition(0, 0);

        }

       
           
        ///<summary>
        ///DrawMap (WIP)
        ///</summary>
        ///<remarks>
        /// Ska skriva ut en karta för spelaren Funkar inte än
        ///</remarks>
        public void DrawMap()
        
        {
       //     StringBuilder sb = new StringBuilder();
       //     int cellCount = 0;
       //
       //     foreach (var value in map)
       //     {
       //         if ((cellCount % 1) == 0)
       //         {
       //             Console.WriteLine((string.Concat(Enumerable.Repeat("-", 22))));
       //         }
       //         if ((cellCount % 1) == 0)
       //         {
       //             Console.Write("|");
       //         }
       //         sb.Append($"{value} ");
       //         cellCount++;
       //
       //         if (map.Length == cellCount)
       //         {
       //             sb.AppendLine(string.Concat(Enumerable.Repeat("-", 22)));
       //         }
       //     }
       //
       //
        }
    }
}
