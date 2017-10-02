using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class InputController
    {
        ///<summary>
        /// Hanterar Spelet med run och items
        ///</summary>
        ///<remarks>
        ///GameHandler Game Kontaktar itemHandler och rooms för att se om saker finns
        ///</remarks>
        GameHandler Game = new GameHandler();

        ///<summary>
        ///inputCheck kollar om kommandot finns (byta till smidigare än massa if satser)
        ///</summary>    
        public bool inputCheck(string UserInput)
        {
            Console.Clear();
            if (UserInput.Contains("show"))
            {
                Game.ShowRoom();
            }
             else if (UserInput.Contains("hjälp"))
             {
                Console.Clear();
                 Console.SetCursorPosition(0, 0);
                 Console.WriteLine("Command Lista:");
                 Console.WriteLine("Movement: go (norr,söder,väster,öster");
                 Console.WriteLine("get namn (plockar upp,namn är namnet på saken)");
                 Console.WriteLine("drop namn (lägger ner,namn är namnet på saken)");
                 Console.WriteLine("use namn on namn  (använder en sak med en annan)");
                 Console.WriteLine("open dörrnamn namn (försöker öppna en dörr med en sak(nyckel tex)");
                 Console.WriteLine("inspect namn (Kollar närmre på en sak)");
                Console.WriteLine("Tryck på en knapp för att fortsätta...");
                 Console.ReadKey();
                 Console.Clear();
            }
            else if (UserInput.Contains("inv"))
            {
                DrawInterface();
                Game.ShowItems();
               
            }

             else if (UserInput.Contains("go"))
            {
                string[] words = UserInput.Split(' ');
                 if (words[1] == "norr" || words[1] == "söder" || words[1] == "väster" || words[1] == "öster")
                {

                   bool end = Game.MoveToNewRoom(words[1]);
                    Game.ShowRoom();
                    return end;

                }
                else { Game.UpdateMap(); }
            }
            else if (UserInput.Contains("open"))
            {
                string[] words = UserInput.Split(' ');
                try
                {
                    DrawInterface();
                    string doorOpen= Game.OpenDoor(words[1], words[2]);
                    Console.SetCursorPosition(35, 26);
                    Console.WriteLine(doorOpen);
                }
                catch (Exception e)
                {
                    DrawInterface();

                }

            }
            else if (UserInput.Contains("use"))
            {
                string[] words = UserInput.Split(' ');
                try
                {
                  string newItem=  Game.UseItemOnItem(words[1], words[3]);
                    DrawInterface();
                    if (string.IsNullOrEmpty(newItem))
                    {
                       
                        Console.SetCursorPosition(35, 26);
                        Console.WriteLine("Det gick inte att annvända som du ville");
                    }
                    else
                    {
                        Console.SetCursorPosition(35, 26);
                        Console.WriteLine("Du annvände " + words[1] + " på " + words[3] + "och fick en " + newItem);
                    }
                    
                }
                catch (Exception e)
                {
                    
                    DrawInterface();


                }

            }
            else if (UserInput.Contains("inspect"))
            {
                string[] words = UserInput.Split(' ');
                try
                {
                    Game.CloseInspect(words[1]);
                }
                catch (Exception e)
                {
                    DrawInterface();

                }

            }
            else if (UserInput.Contains("drop"))
            {
                string[] words = UserInput.Split(' ');
                try
                {
                    Game.DropItem(words[1]);

                }
                catch (Exception e)
                {
                    DrawInterface();

                }

            }
            else if (UserInput.Contains("get"))
            {
                string[] words = UserInput.Split(' ');
                try
                {
                    DrawInterface();
                    string item = Game.PickUpItem(words[1]);
                    Console.SetCursorPosition(35, 26);
                    Console.WriteLine("Du Plocka upp"+ item);
                }
                catch (Exception e)
                {
                    DrawInterface();

                }

            }
            else
            {
                DrawInterface();
                Game.NoCommand();
                
            }
            return true;

        }

        public void StartGame()
        {
            Game.StartGame();
            

        }

        private void DrawInterface()
        {
            Game.UpdateMap();
            Console.SetCursorPosition(35, 26);
            //Console.WriteLine("Skriv hjälp för att få komandon");
        }
    }

}
