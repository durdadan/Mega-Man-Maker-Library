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
            List<Level> authorLevels = api.GetLevelsForAuthor(8575);
            foreach (var l in authorLevels)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(l.Likes);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{l.Dislikes}\t");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(l.DecodeDifficulty());

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(l.Author.Name);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═══════════════════════════════════");
            }


            List<Level> levels = api.GetLevels(Maker.LevelOrder.Downloads, OrderDirection.Desc, 0, 5);
            //List<Level> levels = api.GetLevelsBySearch("kaizo race", 0, 100);
            //foreach (var l in levels)
            //{
            //    Console.WriteLine(l.GetBossName());
            //    Console.WriteLine($"{l.Id}\t{l.Name}");

            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.Write(l.Likes);
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //    Console.Write("/");
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.Write($"{l.Dislikes}\t");

            //    Console.ForegroundColor = ConsoleColor.Gray;
            //    Console.WriteLine(l.DecodeDifficulty());

            //    Console.ForegroundColor = ConsoleColor.DarkCyan;
            //    Console.WriteLine(l.Author.Name);

            //    Console.ForegroundColor = ConsoleColor.Gray;
            //    Console.WriteLine("═══════════════════════════════════");
            //}


            Record r = api.GetLevelRecord(523267);

            Console.WriteLine("Does exist: " + r.Exists);
            Console.WriteLine("Has Record: " + r.HasRecord);
            Console.WriteLine("Num Players: " + r.NumberOfPlayers);
            Console.WriteLine("Is Deleted: " + r.IsDeleted);
            Console.WriteLine("Level Id: " + r.LevelId );
            Console.WriteLine("Record Holder: " + r.RecordHolder);
            Console.WriteLine($"Mili:{r.BestTimeMiliseconds}\tTime:{r.BestTimeReadable}");

            Console.WriteLine("═══════════════════════════════════");

            r = api.GetLevelRecord(523470);

            Console.WriteLine("Does exist: " + r.Exists);
            Console.WriteLine("Has Record: " + r.HasRecord);
            Console.WriteLine("Num Players: " + r.NumberOfPlayers);
            Console.WriteLine("Is Deleted: " + r.IsDeleted);
            Console.WriteLine("Level Id: " + r.LevelId );
            Console.WriteLine("Record Holder: " + r.RecordHolder);
            Console.WriteLine($"Mili:{r.BestTimeMiliseconds}\tTime:{r.BestTimeReadable}");

            Console.WriteLine("═══════════════════════════════════");

            r = api.GetLevelRecord(521853);

            Console.WriteLine("Does exist: " + r.Exists);
            Console.WriteLine("Has Record: " + r.HasRecord);
            Console.WriteLine("Num Players: " + r.NumberOfPlayers);
            Console.WriteLine("Is Deleted: " + r.IsDeleted);
            Console.WriteLine("Level Id: " + r.LevelId );
            Console.WriteLine("Record Holder: " + r.RecordHolder);
            Console.WriteLine($"Mili:{r.BestTimeMiliseconds}\tTime:{r.BestTimeReadable}");

            Console.WriteLine("═══════════════════════════════════");



            //Level level = api.GetLevel(508771);
            //Console.WriteLine(level.GetBossName());
            //Console.WriteLine($"{level.Id}\t{level.Name}");

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write(level.Likes);
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.Write("/");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write($"{level.Dislikes}\t");

            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine(level.DecodeDifficulty());

            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine(level.Author.Name);

            //Console.ForegroundColor = ConsoleColor.Gray;

            //Console.WriteLine("═══════════════════════════════════");

            //level = api.GetLevel(509843);
            //Console.WriteLine(level.GetBossName());
            //Console.WriteLine($"{level.Id}\t{level.Name}");

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write(level.Likes);
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.Write("/");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write($"{level.Dislikes}\t");

            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine(level.DecodeDifficulty());

            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine(level.Author.Name);

            //Console.ForegroundColor = ConsoleColor.Gray;

            //Console.WriteLine("═══════════════════════════════════");

        }

    }
}
