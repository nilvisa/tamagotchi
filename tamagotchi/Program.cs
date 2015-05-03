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
            Write("Hi, what's your name?");
            Console.WriteLine();
            string you = Console.ReadLine();
            Console.WriteLine();

            Write("Name your Tamagotchi!");
            YouTalk(you);
            string name = Console.ReadLine();

            // EGG
            Console.Clear();
            var tama = new Tama(name);
            tama.WriteName();
            tama.DrawTama();
            
            Write("Hit ENTER to welcome " + tama.Name + " to the wolrd!");
            Console.Read();
            tama.ChangeStage("baby");

            // BABY
            Console.Clear();
            tama.WriteTama();
            tama.TamaTalks("Hi " + you + "! *tummy rumbling*");           
            Write(tama.Name + " is very hungry, you have to feed it!");          
            Feed(tama, you);

            Console.Clear();
            tama.WriteTama();
            tama.TamaTalks(tama.food != "nothing" ? "Yum yum yum, " + tama.food + "!" : "*rumble rumble*");
            tama.TamaTalks("Play with me!");
            bool play = YesNo(tama, you);

            Console.Clear();
            tama.WriteTama();
            tama.TamaTalks(play ? "YAY!" : "Boooo!");
            tama.TamaTalks("I'm still hungry! Feed me!");          
            Feed(tama, you);

            Console.Clear();
            tama.WriteTama();
            tama.TamaTalks(tama.food != "nothing" ? "Nom nom nom, delicious " + tama.food + "!" : "Iiih I'm just a baby, I need food!");
            tama.TamaTalks("It's getting late and I'm really sleepy.");
            tama.TamaTalks("Will you turn off the lights for me?");
            bool lights = YesNo(tama, you);
            if (lights)
            {
                tama.Happy += 1;
                tama.Dicipline += 1;
                Night(tama);
            }
            else
            {
                Console.Clear();
                tama.WriteTama();
                tama.TamaTalks("Please, I'm really sleepy! *yaaaawn*");
                lights = YesNo(tama, you);

                if (lights)
                {
                    tama.Happy += 1;
                    Night(tama);
                }
                else
                {
                    tama.Hungry = (tama.Hungry != 0 ? tama.Hungry -= 1 : 0);
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    Console.Clear();
                    tama.WriteTama();
                    tama.TamaTalks("*throws temper tantrum*");
                    Write("Sorry, but now booth you and " + tama.Name + " will be upp all night...");
                    Console.ReadLine();
                    Night(tama);
                }
            }

            tama.WriteTama();
            tama.TamaTalks(tama.Happy > 1 ? "Good morning " + you + "!" : "I don't like you " + you + " very much *sob sob*");
            Write("Time for breakfast!");
            Feed(tama, you);

            Console.Clear();
            tama.WriteTama();

            if (tama.Poop == 0)
            {
                tama.ChangeStage("dead");
                Console.Clear();
                tama.WriteTama();
                Write("Poor " + tama.Name + " starved to death!");
                Write("You shouldn't have pets, " + you+ "...");
                Console.WriteLine();
                Write("Hit ENTER to shut down.");
                Console.ReadLine();
                //END
            }

            Write("Looks like " + tama.Name + " made a doo-doo, will you clean it?");
            bool poop = YesNo(tama, you);
            if(poop) tama.Poop = 0;

            if (tama.Dicipline > 2) tama.ChangeStage("goodTeen");
            else tama.ChangeStage("badTeen");

            //TEEN
            Console.Clear();
            tama.WriteTama();
                       

        }

        static void Write(string String)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(); 
            Console.WriteLine(String);
            Console.ForegroundColor = ConsoleColor.White;            
        }

        static void YouTalk(string you)
        {
            Console.WriteLine();
            Console.Write(you + "> ");
        }

        static bool YesNo(Tama tama, string you)
        {
            bool answer = false;
            bool final = false;

            Write("[ YES ]   [ NO ]");
            YouTalk(you);

            while (answer == false)
            {
                string readLine = Console.ReadLine().ToLower();

                if (readLine == "yes" || readLine == "y")
                {
                    tama.Happy += 1;
                    answer = true;
                    final = true; 
                }
                else if (readLine == "no" || readLine == "n")
                {
                    tama.Happy = (tama.Happy != 0 ? tama.Happy -= 1 : 0);
                    answer = true;
                    final = false;
                }
                else
                {
                    Write("[ YES ]   [ NO ]");
                    YouTalk(you);
                    answer = false;
                }
                
            }
            return final;          
        }

        static void Feed(Tama tama, string you)
        {
            bool fed = false;
            
            while (fed == false)
            {
                tama.food = Console.ReadLine().ToLower();

                if (tama.food == "bread")
                {
                    tama.Dicipline += 1;
                    tama.Hungry += 3;
                    fed = true;
                }
                else if (tama.food == "candy")
                {
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    tama.Hungry += 2;
                    fed = true;
                }
                else if (tama.food == "nothing")
                {
                    tama.Hungry = (tama.Hungry != 0 ? tama.Hungry -= 1 : 0);
                    fed = true;
                }
                else
                {
                    Write("Choose from [ BREAD ] [ CANDY ] [ NOTHING ]");
                    YouTalk(you);
                }
                
            }
 
        }

       
        static void Night(Tama tama)
        {
            Console.Clear();
            Console.WriteLine("NIGHT!");
            Write("hit ENTER to wake " + tama.Name);
            Console.ReadLine();
        }

        
    }

      
    

}
