using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamagotchi
{
    class Tama
    {
        public string Name { get; set; }
        public int Dicipline { get; set; }
        public int Hungry { get; set; }
        public int Happy { get; set; }
        public int Poop {get; set;}
        public bool Good { get; set; }

        public string food;

        public string Stage { get; set; }
        ConsoleColor Color { get; set; }

        public Tama(string name)
        {
            Name = name;
            Stage = "egg";
            Color = ConsoleColor.DarkMagenta;
        }

        public void WriteTama()
        {
            if (Hungry > 5)
            {
                Poop += 1;
                Hungry = 2;
            }

            Console.Clear();
            WriteName();
            DrawTama();
            DrawChart();

            if (Poop > 0) DrawPoop();            
        }

        public void ChangeStage(string stage)
        {
            Stage = stage;

            if (Stage == "goodTeen" || Stage == "goodAdult" || Stage == "angel")
                Good = true;
            else
                Good = false;
        }

        public void WriteName()
        {
            Console.SetCursorPosition(7, 1);
            Console.WriteLine("  ♥  ♥  ♥  {0}  ♥  ♥  ♥", Name);
            Console.WriteLine();
        }

        public void DrawChart()
        {
            Console.SetCursorPosition(5, 17);
      
            Console.Write("Dicipline: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for(var i = 0; i < Dicipline; i++)
            {
                Console.Write("♥");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("  Hungry: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (var i = 0; i < Hungry; i++)
            {
                Console.Write("♥");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("  Happy: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (var i = 0; i < Happy; i++)
            {
                Console.Write("♥");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawPoop()
        {
            Console.SetCursorPosition(5, 19);
            Console.Write("Poop: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (var i = 0; i < Poop; i++)
            {
                Console.Write("▲");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();           
        }

        public void DrawTama()
        {            
            switch(Stage)
            {
                case "baby":
                    Color = ConsoleColor.Magenta;
                    Baby();
                    break;
                case "goodTeen":
                    Color = ConsoleColor.Cyan;
                    GoodTeen();
                    break;
                case "badTeen":
                    Color = ConsoleColor.Green;
                    BadTeen();
                    break;
                case "goodAdult":
                    Color = ConsoleColor.Blue;
                    GoodAdult();
                    break;
                case "badAdult":
                    Color = ConsoleColor.DarkGreen;
                    BadAdult();
                    break;
                case "angel":
                    Color = ConsoleColor.DarkCyan;
                    Angel();
                    break;
                case "dead":
                    Color = ConsoleColor.DarkGray;
                    Dead();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public void TamaTalks(string String)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.Write("{0}> ", Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String);
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);  
        }

        public void Hatching()
        {
            for(int i = 0; i < 15; i++)
            {
                Console.Clear();

                WriteName();

                if (i % 2 == 0)
                    Egg();
                else if (i % 3 == 0)
                    Egg2();
                else
                    Egg3();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(Name + " is hatching!!");
                System.Threading.Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Clear();
            WriteName();
            Egg();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(500);

            Console.Clear();
            WriteName();
            Egg4();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            TamaTalks("MOMMY!");
            System.Threading.Thread.Sleep(400);
            TamaTalks("*squeeek*");
            System.Threading.Thread.Sleep(800);
            Console.ForegroundColor = ConsoleColor.White;
        }

        void Egg()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                    ■■       ");
            Console.WriteLine("                  ■    ■     ");
            Console.WriteLine("                ■        ■   ");
            Console.WriteLine("               ■          ■  ");
            Console.WriteLine("              ■            ■ ");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("               ■          ■  ");
            Console.WriteLine("                 ■ ■■■■ ■    ");
         }

        void Egg2()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■■        ");
            Console.WriteLine("                 ■    ■      ");
            Console.WriteLine("               ■        ■    ");
            Console.WriteLine("              ■          ■   ");
            Console.WriteLine("             ■             ■  ");
            Console.WriteLine("            ■               ■ ");
            Console.WriteLine("            ■               ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("               ■          ■  ");
            Console.WriteLine("                 ■ ■■■■ ■    ");
        }

        void Egg3()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                     ■■      ");
            Console.WriteLine("                   ■    ■     ");
            Console.WriteLine("                 ■        ■   ");
            Console.WriteLine("               ■           ■  ");
            Console.WriteLine("              ■             ■ ");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("             ■               ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("               ■          ■  ");
            Console.WriteLine("                 ■ ■■■■ ■    ");
        }

        void Egg4()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                    ■■       ");
            Console.WriteLine("                  ■    ■     ");
            Console.WriteLine("                ■        ■   ");
            Console.WriteLine("              ■            ■ ");
            Console.WriteLine("             ■  ■ ■ ■■ ■ ■  ■");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("              ■  ■      ■  ■ ");
            Console.WriteLine("              ■    ■■■■    ■ ");
            Console.ForegroundColor = Color;
            Console.WriteLine("             ■  ■ ■ ■■ ■ ■  ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("             ■              ■");
            Console.WriteLine("               ■          ■  ");
            Console.WriteLine("                 ■ ■■■■ ■    ");
        }


        void Baby()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                  ■ ■■■■ ■   ");
            Console.WriteLine("                ■          ■ ");
            Console.WriteLine("               ■  ■      ■  ■");
            Console.WriteLine("               ■    ■■■■    ■");
            Console.WriteLine("               ■            ■");
            Console.WriteLine("                ■          ■ ");
            Console.WriteLine("                  ■ ■■■■ ■   ");
        } 

        void GoodTeen()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.WriteLine("                  ■ ■■■■ ■■   ");
            Console.WriteLine("                ■           ■  ");
            Console.WriteLine("               ■  ■       ■  ■ ");
            Console.WriteLine("               ■    ■■■■■    ■ ");
            Console.WriteLine("              ■■             ■■");
            Console.WriteLine("                ■           ■  ");
            Console.WriteLine("                 ■    ■    ■   ");
            Console.WriteLine("                  ■  ■ ■  ■   ");
            Console.WriteLine("                   ■     ■     ");
        }

        void BadTeen()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();
            Console.WriteLine("                     ■ ■■■ ■      ");
            Console.WriteLine("                   ■         ■    ");
            Console.WriteLine("              ■■■■    ■   ■    ■  ");
            Console.WriteLine("             ■■■■■              ■ ");
            Console.WriteLine("                  ■            ■  ");
            Console.WriteLine("                  ■            ■  ");
            Console.WriteLine("                  ■             ■");
            Console.WriteLine("                  ■      ■       ■");
            Console.WriteLine("                    ■ ■ ■  ■ ■ ■  ");
        }

        void GoodAdult()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■       ■     ");
            Console.WriteLine("                  ■■■■   ■■■■    ");
            Console.WriteLine("                 ■■■■■■■■■■■■■   ");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("                ■  ■       ■  ■  ");
            Console.WriteLine("                ■     ■■■     ■  ");
            Console.WriteLine("              ■■■             ■■■");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("                  ■    ■    ■    ");
            Console.WriteLine("                   ■  ■ ■  ■     ");
            Console.WriteLine("                    ■     ■      ");
        }

        void BadAdult()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                     ■ ■■■ ■      ");
            Console.WriteLine("                   ■         ■    ");
            Console.WriteLine("             ■■■■■    ■   ■    ■  ");
            Console.WriteLine("               ■               ■  ");
            Console.WriteLine("             ■■■■■              ■ ");
            Console.WriteLine("                  ■            ■  ");
            Console.WriteLine("                  ■            ■  ");
            Console.WriteLine("                  ■              ■");
            Console.WriteLine("                  ■      ■       ■");
            Console.WriteLine("                    ■   ■ ■   ■ ■ ");
            Console.WriteLine("                     ■      ■     ");
        }

        void Angel()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                     ■■■■■       ");
            Console.WriteLine("                                 ");
            Console.WriteLine("                  ■■ ■ ■ ■ ■■    ");
            Console.WriteLine("                 ■           ■   ");
            Console.WriteLine("      ■         ■  ■       ■  ■  ");
            Console.WriteLine("    ■ ■ ■       ■     ■■■     ■  ");
            Console.WriteLine("      ■         ■             ■  ");
            Console.WriteLine("      ■          ■           ■   ");
            Console.WriteLine("                   ■       ■     ");
            Console.WriteLine("                      ■ ■        ");
            Console.WriteLine("                       ■         ");
        }

        void Dead()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("                   ■ ■ ■ ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("             ■      R.I.P.     ■");
            Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■ ■ ■ ■      ");
        }
    }
}
