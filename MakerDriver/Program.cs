using System;
using System.Collections.Generic;
using Maker;

namespace MakerDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Maker.Api api = new Maker.Api();
            List<Level> levels = api.GetLevels();
            foreach (var l in levels)
            {
                Console.WriteLine(l.GetBossName());
                Console.Write(l.GetId() + "\t");
                Console.WriteLine(l.GetName());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(l.GetLikes());
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(l.GetDislikes() + "\t");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(l.DecodeDifficulty());

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(l.GetAuthor().GetName());

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═══════════════════════════════════");
            }

            Level level = api.GetLevel(52);
            Console.WriteLine(level.GetBossName());
            Console.Write(level.GetId() + "\t");
            Console.WriteLine(level.GetName());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(level.GetLikes());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(level.GetDislikes() + "\t");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(level.DecodeDifficulty());

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(level.GetAuthor().GetName());

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("═══════════════════════════════════");

        }
       
    }
}
