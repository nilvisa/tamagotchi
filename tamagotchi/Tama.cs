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

        public string food;

        string Stage { get; set; }
        ConsoleColor Color { get; set; }

        public Tama(string name)
        {
            Name = name;
            Stage = "egg";
            Color = ConsoleColor.Magenta;
        }

        public void WriteTama()
        {
            WriteName();
            DrawTama();
            DrawChart();
        }

        public void ChangeStage(string stage)
        {
            Stage = stage;
        }

        public void WriteName()
        {
            Console.WriteLine();
            Console.WriteLine("   ♥  ♥  ♥  {0}  ♥  ♥  ♥", Name);
            Console.WriteLine();
        }

        public void DrawChart()
        {
            Console.WriteLine();

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

        public void DrawTama()
        {
            Console.WriteLine();

            switch(Stage)
            {
                case "egg":
                    Color = ConsoleColor.Magenta;
                    Egg();
                    break;
                case "baby":
                    Color = ConsoleColor.DarkMagenta;
                    Baby();
                    break;
                case "goodTeen":
                    Color = ConsoleColor.Cyan;
                    GoodTeen();
                    break;
                case "badTeen":
                    Color = ConsoleColor.Red;
                    BadTeen();
                    break;
                case "goodAdult":
                    Color = ConsoleColor.Blue;
                    GoodAdult();
                    break;
                case "badAdult":
                    BadAdult();
                    Color = ConsoleColor.DarkRed;
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
            Console.Write("{0}> ", Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String);
            Console.WriteLine();
        }

        void Egg()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("       ■■       ");
            Console.WriteLine("     ■    ■     ");
            Console.WriteLine("   ■        ■   ");
            Console.WriteLine("  ■          ■  ");
            Console.WriteLine(" ■            ■ ");
            Console.WriteLine("■              ■");
            Console.WriteLine("■              ■");
            Console.WriteLine("■              ■");
            Console.WriteLine("  ■          ■  ");
            Console.WriteLine("    ■ ■■■■ ■    ");
         }


        void Baby()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("   ■ ■■■■ ■   ");
            Console.WriteLine(" ■          ■ ");
            Console.WriteLine("■  ■      ■  ■");
            Console.WriteLine("■    ■■■■    ■");
            Console.WriteLine("■            ■");
            Console.WriteLine(" ■          ■ ");
            Console.WriteLine("   ■ ■■■■ ■   ");
        }

        void GoodTeen()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("    ■ ■■■■ ■■   ");
            Console.WriteLine("  ■           ■  ");
            Console.WriteLine(" ■  ■       ■  ■ ");
            Console.WriteLine(" ■    ■■■■■    ■ ");
            Console.WriteLine("■■             ■■");
            Console.WriteLine("  ■           ■  ");
            Console.WriteLine("   ■    ■    ■   ");
            Console.WriteLine("    ■  ■ ■  ■   ");
            Console.WriteLine("     ■     ■     ");
        }

        void BadTeen()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("        ■ ■■■ ■      ");
            Console.WriteLine("      ■         ■    ");
            Console.WriteLine(" ■■■■    ■   ■    ■  ");
            Console.WriteLine("■■■■■              ■ ");
            Console.WriteLine("     ■            ■  ");
            Console.WriteLine("     ■            ■  ");
            Console.WriteLine("     ■             ■");
            Console.WriteLine("     ■      ■       ■");
            Console.WriteLine("       ■ ■ ■  ■ ■ ■  ");
        }

        void GoodAdult()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("     ■       ■     ");
            Console.WriteLine("    ■■■■   ■■■■    ");
            Console.WriteLine("   ■■■■■■■■■■■■■   ");
            Console.WriteLine("   ■           ■   ");
            Console.WriteLine("  ■  ■       ■  ■  ");
            Console.WriteLine("  ■     ■■■     ■  ");
            Console.WriteLine("■■■             ■■■");
            Console.WriteLine("   ■           ■   ");
            Console.WriteLine("    ■    ■    ■    ");
            Console.WriteLine("     ■  ■ ■  ■     ");
            Console.WriteLine("      ■     ■      ");
        }

        void BadAdult()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("        ■ ■■■ ■      ");
            Console.WriteLine("      ■         ■    ");
            Console.WriteLine("■■■■■    ■   ■    ■  ");
            Console.WriteLine("  ■               ■ ");
            Console.WriteLine("■■■■■              ■ ");
            Console.WriteLine("     ■            ■  ");
            Console.WriteLine("     ■            ■  ");
            Console.WriteLine("     ■              ■");
            Console.WriteLine("     ■      ■       ■");
            Console.WriteLine("       ■   ■ ■   ■ ■ ");
            Console.WriteLine("        ■      ■     ");
        }

        void Dead()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("      ■ ■ ■ ■      ");
            Console.WriteLine("      ■     ■      ");
            Console.WriteLine("■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("■      R.I.P.     ■");
            Console.WriteLine("■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("      ■     ■      ");
            Console.WriteLine("      ■     ■      ");
            Console.WriteLine("      ■     ■      ");
            Console.WriteLine("      ■     ■      ");
            Console.WriteLine("      ■     ■      ");
            Console.WriteLine("      ■ ■ ■ ■      ");
        }
    }
}
