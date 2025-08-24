using System;
using System.Text.RegularExpressions;

namespace Maker
{
    public class Level
    {
        #region Properties

        public int Id { get; set;}
        public string Name { get; set; }
        public double? Difficulty { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Boss { get; set; }
        public Author Author { get; set; }
        public DateTime Date { get; set; }
        public int Downloads { get; set; }

        private enum BossNames
        {
            orb_or_party_ball =    -1,
            unspecified =          1,
            pharaoh_man =           2,
            top_man =               3,
            crash_man =             4,
            cut_man =               5,
            metal_man =             6,
            toad_man =              7,
            plant_man =             8,
            gemini_man =            9,
            spark_man =             10,
            napalm_man =            11,
            stone_man =             12,
            bomb_man =              13,
            knight_man =            14,
            // orb                  15
            // party_ball           16
            ice_man =               17,
            time_man =              18,
            wood_man =              19,
            magnet_man =            20,
            hard_man =              21,
            bubble_man =            22,
            skull_man =             23,
            ring_man =              24,
            crystal_man =           25,
            charge_man =            26,
            flame_man =             27,
            wind_man =              28,
            shade_man =             29,
            spring_man =            30,
            concrete_man =          31,
            tornado_man =           32,
            multiple_endings =      33,
            //                      34
            astro_man =             35,
            //                      36,
            grenade_man =           37,
            sheep_man =             38,
            pump_man  =             39,
            blast_man =             40,
            bounce_man =            41,
            quick_man =             42,
            yamato_man =            43,
            fire_man =              44,
            splash_woman =          45,
            freeze_man =            46,
            strike_man =            47


        }

        #endregion properties

        #region Constructors

        public Level ()
        {
        }

        public Level(int id, string name, double? difficulty, int likes, int dislikes, int boss, Author author, DateTime date,int downloads)
        {
            this.Id = id;
            this.Name = name;
            this.Difficulty = difficulty;
            this.Likes = likes;
            this.Dislikes = dislikes;
            this.Boss = boss;
            this.Author = author;
            this.Date = date;
            this.Downloads = downloads;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets a Human readable difficulty string.
        /// </summary>
        /// <returns>a string signifying how difficult a level is.</returns>
        public string DecodeDifficulty() {
            string difficultyString = "Unknown";
            if (this.Difficulty != null)
            {
                double difficulty = (int)((double)this.Difficulty * 100);
                if (difficulty >= 99)
                {
                    difficultyString = "Kaizo";
                }
                else if (difficulty < 99 && difficulty > 90)
                {
                    difficultyString = "Hard";
                }
                else if (difficulty < 90 && difficulty > 80)
                {
                    difficultyString = "Difficult";
                }
                else if (difficulty < 80 && difficulty > 70)
                {
                    difficultyString = "Challenging";
                }
                else if (difficulty < 70 && difficulty > 60)
                {
                    difficultyString = "Normal";
                }
                else if (difficulty < 60 && difficulty > 30)
                {
                    difficultyString = "Pretty Easy";
                }
                else if (difficulty < 30 && difficulty > 15)
                {
                    difficultyString = "Easy";
                }
                else
                {
                    difficultyString = "Too Easy";
                }
            }

            return difficultyString;
        }

        /// <summary>
        /// Gets the name of a boss from the boss field in a level.
        /// </summary>
        /// <returns>A string containing the boss' name.</returns>
        public string GetBossName()
        {
            string bossName = Enum.GetName(typeof(BossNames), this.Boss);
            bossName = bossName.Replace('_', ' ');
            bossName = Regex.Replace(bossName, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return bossName;
        }
        #endregion
    }
}
