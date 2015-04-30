using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name your Tamagotchi!");
            Console.WriteLine();
            Console.Write("You> ");
            string name = Console.ReadLine();

            // EGG
            Console.Clear();
            var tama = new Tama(name);
            tama.WriteName();
            tama.DrawTama();
            
            Console.WriteLine("Hit ENTER to welcome {0} to the wolrd!", tama.Name);
            Console.Read();
            tama.ChangeStage("baby");

            // BABY
            Console.Clear();
            tama.WriteTama();
           
            Console.WriteLine("{0} is very hungry, you have to feed it!", tama.Name);
            Console.WriteLine();

            Feed(tama);
            
            Console.Clear();
            tama.WriteTama();

            if (tama.food != "nothing")
            {
                tama.TamaTalks("Yum yum yum, "+tama.food+"!");
            }          



        }

        static void Feed(Tama tama)
        {
            bool fed = false;
            
            while (fed == false)
            {
                tama.food = Console.ReadLine().ToLower();

                if (tama.food == "bread")
                {
                    tama.Dicipline += 2;
                    tama.Hungry += 2;
                    fed = true;
                }
                else if (tama.food == "candy")
                {
                    tama.Hungry += 2;
                    fed = true;
                }
                else if (tama.food == "nothing")
                {
                    fed = true;
                }
                else
                {
                    Console.WriteLine("Choose from [ BREAD ] [ CANDY ] [ NOTHING ]");
                    Console.Write("You> ");
                }
                
            }
 
        }

        
    }

      
    

}
