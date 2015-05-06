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
            string you = "";
            string name = "";

            while(you == "")
            {
                Write("Hi, what's your name?");
                Console.WriteLine();
                you = Console.ReadLine();
                Console.WriteLine();                    
            }
          
            while(name == "")
            {
                Write("Name your Tamagotchi!");
                YouTalk(you);
                name = Console.ReadLine();
            }


            // EGG
            var tama = new Tama(name);
            tama.Hatching();
            tama.ChangeStage("baby");


            // BABY
            tama.WriteTama();
            tama.TamaTalks("Hi " + you + "! *tummy rumbling*");          
            Write(tama.Name + " is very hungry, you have to feed it!");          
            Feed(tama, you);

            tama.WriteTama();
            tama.TamaTalks(tama.food != "nothing" ? "Yum yum yum, " + tama.food + "!" : "*rumble rumble*");
            tama.TamaTalks("Play with me!");
            bool play = YesNo(tama, you);

            tama.WriteTama();
            tama.TamaTalks(play ? "YAY!" : "Boooo!");
            tama.TamaTalks("I'm still hungry! Feed me!");          
            Feed(tama, you);

            tama.WriteTama();
            tama.TamaTalks(tama.food != "nothing" ? "Nom nom nom, delicious " + tama.food + "!" : "Iiih I'm just a baby, I need food!");
            tama.TamaTalks("It's getting late and I'm really sleepy. \r\n Will you turn off the lights for me?");
            bool lights = YesNo(tama, you);
            if (lights)
            {
                tama.Happy += 1;
                tama.Dicipline += 1;
                Night(tama);
            }
            else
            {
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
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    tama.WriteTama();
                    tama.TamaTalks("*throws temper tantrum*");
                    Write("Sorry, but now both you and " + tama.Name + " will be upp all night...");
                    System.Threading.Thread.Sleep(2000);
                    Night(tama);
                }
            }

            tama.WriteTama();
            tama.TamaTalks(tama.Happy > 1 ? "Good morning " + you + "!" : "I don't like you " + you + " very much *sob sob*");
            Write("Time for breakfast!");
            Feed(tama, you);

            tama.WriteTama();

            if (tama.Poop == 0)
            {
                tama.ChangeStage("dead");
                tama.WriteTama();
                Write("Poor " + tama.Name + " starved to death!");
                Write("You shouldn't have pets, " + you+ "...");
                Console.WriteLine();
                Write("Hit ENTER to shut down.");
                Console.ReadLine();
                return;
                //END
            }

            Write("Looks like " + tama.Name + " made a doo-doo, will you clean it?");
            bool poop = YesNo(tama, you);
            if(poop) tama.Poop = 0;

            if (tama.Dicipline > 2) tama.ChangeStage("goodTeen");
            else tama.ChangeStage("badTeen");


            //TEEN
            tama.WriteTama();
            if(tama.Good)
            {
                tama.TamaTalks("Thank you "+you+"!");
                Write("Oh! " + tama.Name + " just grew!");
                Write("And it looks like it's healthy and well disciplined.\r\n Keep raising it this way!");
            }
            else
            {
                tama.TamaTalks("What ever...");
                Write("Uh oh! Looks like " + tama.Name + " just grew into a spoiled teen!");
                Write("You should really step up your parenting game...");
            }

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
            tama.TamaTalks(tama.Good ? "Want to play a game!?" : "Entertain me!");
            play = YesNo(tama, you);

            tama.WriteTama();
            if (tama.Good) tama.TamaTalks(play ? "You're so much fun! All that playing made me hungry!" : "Ok, next time... May I have something to eat?");
            else tama.TamaTalks(play ? "You call that fun? Now - FEED ME!" : "*Humpf* FEED ME!");
            Feed(tama, you);

            tama.WriteTama();
            Write("It's getting late, you should put " + tama.Name + " to bed and turn off the lights!");
            lights = YesNo(tama, you);
            bool stayUp;

            if (tama.Good)
            {
                if (lights)
                {
                    tama.Dicipline += 1;
                    tama.TamaTalks("Good night " + you + "!");
                    System.Threading.Thread.Sleep(1000);          
                }
                else
                {
                    tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);
                    tama.TamaTalks("So I can stay up all night!?");
                    stayUp = YesNo(tama, you);

                    if(stayUp)
                    {
                        tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 3 : 0);
                        tama.WriteTama();
                        Write("Not a wise decision...");
                        lights = false;
                        System.Threading.Thread.Sleep(2000);          
                    }
                    else
                    {
                        tama.Happy += 1;
                    }
                }
            }
            else
            {
                var complaint = new List<string>();
                complaint.AddRange(new String[] {
                        "I'm not going to bed!",
                        "You can't make me!",
                        "Look at me - NOT SLEEPING! You're not the boss of me!",
                        });

                for (int i = 0; i < 3; i++)
                {
                    if (lights) tama.Dicipline += 2;
                    else tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 1 : 0);

                    tama.WriteTama();
                    tama.TamaTalks(complaint[i]);
                    lights = YesNo(tama, you);
                }

                if(!lights)
                {
                    tama.TamaTalks("Good, I'm never going to sleep.");
                    Write("You have to put " + name + " to bed!");
                    lights = YesNo(tama, you);
                    if (!lights)
                    {
                        tama.Dicipline = (tama.Dicipline != 0 ? tama.Dicipline -= 2 : 0);
                        tama.Happy = (tama.Happy != 0 ? tama.Happy -= 2 : 0);
                        tama.WriteTama();
                        tama.TamaTalks("*going berserk*");
                        Write("Suit yourself...");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        tama.Happy = (tama.Happy != 0 ? tama.Happy -= 1 : 0);
                        tama.Dicipline += 1;
                    }
                }
            }
            Night(tama);

            if(!lights)
            {
                Console.Clear();
                Write("Since you let "+ tama.Name+ " stay up all night it's not waking up.");
                Write("If you don't want to end up with a bad pet \r\n you need to let it know who's the boss!");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine();
                Write("Wake " + tama.Name + " up!"); 
                bool wake = YesNo(tama, you);

                while(!wake)
                {
                    var wakeIt = new List<string>();
                    wakeIt.AddRange(new String[] {
                        "You should really wake "+tama.Name+" up...",
                        "Wake it!",
                        "Wake "+tama.Name+" or it will become lazy!",
                        "Really, you should take some responsibility for your pet!",
                        you+", wake it!!",
                        "Come on, wake "+tama.Name+" up!",
                        "Wake it up now!"
                        });
                    Random r = new Random();
                    int index = r.Next(wakeIt.Count);

                    tama.TamaTalks("Zzzzzzz...");
                    Write(wakeIt[index]);
                    wake = YesNo(tama, you);
                }
                if (wake) tama.Dicipline += 1;
            }

            tama.WriteTama();
            tama.TamaTalks(tama.Good ? "Good morning "+you+"! \r\n Can I have some breakfast, please?" : "Why did you wake me up!? \r\n You better give me something tasty for breakfast... \r\n I only want candy!");
            Feed(tama, you);

            if(!tama.Good)
            {
                int i = 0;

                while (tama.food == "bread")
                {   
                    var complaint = new List<string>();
                    complaint.AddRange(new String[] {
                        "Bread isn't tasty... I want candy!",
                        "I told you! I don't want bread, I want candy!!",
                        "NOOOO BREEEAAAD!!!"
                        });
                    
                    tama.Hungry = (tama.Hungry != 0 ? tama.Hungry -= 3 : 0);
                    tama.TamaTalks(complaint[i]);
                    i += 1;
                    if (i == 3) break;
                    Feed(tama, you);
                }

                Write(tama.food == "candy" ? "You shouldn't reward such bad behavior with candy..." : "Good, you're starting to make some progress.");
                System.Threading.Thread.Sleep(2000);          
            }

            tama.WriteTama();
            tama.TamaTalks(tama.Good ? "YUMMM, " + tama.food + "!" : tama.food + "... *pout*");
            if(tama.Poop > 0)
            {
                Write("Looks like you need to clean up after "+tama.Name+". \r\n Will you do it");
                poop = YesNo(tama, you);
                if(poop) tama.Poop = 0;
            }

            if(tama.Poop < 0 || tama.Happy < 3)
            {
                Write("Oh no, " + tama.Name + " isn't doing so well... \r\n You have to give it some medecine!");
                bool meds = YesNo(tama, you);
                if (!meds)
                {
                    tama.ChangeStage("dead");
                    tama.WriteTama();
                    Write("Why, " + you + "!? \r\n Now " + tama.Name + " is dead...");
                    Write("You really shouldn't have pets, " + you + "...");
                    Console.WriteLine();
                    Write("Hit ENTER to shut down.");
                    Console.ReadLine();
                    return;
                    //END
                }
                else
                {
                    tama.Happy += 2;
                }
            }

            tama.ChangeStage(tama.Dicipline > 3 ? "goodAdult" : "badAdult");
            tama.WriteTama();
            Write(tama.Good ? "Good job "+you+", \r\n you've raised your "+tama.Name+" to become good and well behaved pet!" : "Sorry, "+you+". You haven't done such a good job in raising "+tama.Name+"...");
            if (tama.Good)
            {
                tama.TamaTalks("Would you like to play with me?");
                play = YesNo(tama, you);

                int i = 0;
                while (!play)
                {
                    var wannaPlay = new List<string>();
                    wannaPlay.AddRange(new String[] {
                        "But I thought we had fun together,\r\n won't you play with me?",
                        "You don't like me anymore? I want to play with you!",
                        "Now I'm very sad... Please play with me?",
                        "*cries*"
                        });

                    tama.Happy = (tama.Happy != 0 ? tama.Happy -= 1 : 0);
                    tama.TamaTalks(wannaPlay[i]);
                    i += 1;
                    if (i == 4) break;
                    YesNo(tama, you);
                }
            }
            else
            {
                Write("You should play some with "+tama.Name+".");
                play = YesNo(tama, you);

                int i = 0;
                while (play)
                {
                    var wannaPlay = new List<string>();
                    wannaPlay.AddRange(new String[] {
                        "I don't wanna play with you...",
                        "Didn't you hear me? I don't want to play!",
                        "NOOOOO!"
                        });

                    tama.Happy += 1;
                    tama.Dicipline += 1;
                    tama.TamaTalks(wannaPlay[i]);
                    Write("Play with " + tama.Name);
                    i += 1;
                    if (i == 3) break;
                    YesNo(tama, you);
                }
            }

            tama.WriteTama();
            if(tama.Good) tama.TamaTalks(play ? "That was so much fun " + you + " !" : "I'm sad now...");
            else tama.TamaTalks(play ? "That was so much fun... NOT!" : "What ever...");

            tama.TamaTalks("I'm so cold, will you comfort me?");
            var comfort = YesNo(tama, you);

            if(comfort)
            {
                tama.Happy += 2;
                tama.TamaTalks("It feels like I'm slipping away... \r\n");
                tama.TamaTalks(tama.Happy > 4 ? "You've been so good to me..." : "Thank you for comforting me, even though I acted bad...");
            }

            System.Threading.Thread.Sleep(2000);          

            tama.ChangeStage(tama.Happy > 4 ? "angel" : "dead");
            tama.WriteTama();
            if(tama.Good)
            {
                Write(tama.Name + " has passed... You took good care of it. It had a happy life!");
                Write("Hit ENTER to exit the game.");
                Console.ReadLine();
                return;
                //END
            }
            else
            {
                Write(tama.Name + " has passed... \r\n Sorry, but you're a terrible pet-owner "+you);
                Write("Hit ENTER to exit the game.");
                Console.ReadLine();
                return;
                //END
            }

          
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

            Write("Choose from [ BREAD ] [ CANDY ] [ NOTHING ]");
            YouTalk(you);                     
            
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

            Console.SetCursorPosition(7, 2);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("        *   *   *    ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("NIGHT TIME");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("    *   *   * ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var stars = new List<string>();
            stars.AddRange(new String[] {
                        "        *       ",
                        "              *       ",
                        "    *            ",
                        "          *          ",
                        "  *        ",
                        "           *    ",
                        "        *      "
                        });


            for (int i = 0; i < 180; i++ )
            {
                
                Random s = new Random();
                int index = s.Next(stars.Count);

                if(i % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.Gray;
                else
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                
                Console.Write(stars[index]);
                System.Threading.Thread.Sleep(1);
                
             }

            System.Threading.Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.White;

        }

        
    }

      
    

}
