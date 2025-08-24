using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Maker
{
    /// <summary>
    /// A selection of valid Level Sort Order Directions
    /// </summary>
    public enum OrderDirection
    {
        Asc,
        Desc
    }

    /// <summary>
    /// An selection of valid Level Sort Orders
    /// </summary>
    public enum LevelOrder
    {
        Date,
        Random,
        Quality,
        Score,
        Downloads
    }

    public class Api
    {
        /// <summary>
        ///     Gets a paginated list of levels.
        /// </summary>

        /// <param name="order">A string representing the order by column.</param>
        /// <param name="orderDirection">A string representing the orderby direction.</param>
        /// <param name="page">An int representing the page you are requesting.</param>
        /// <param name="size">An int representing the number of levels in a page.</param>
        /// <returns>A List of levels.</returns>
        public List<Level> GetLevels(LevelOrder order, OrderDirection orderDirection, int page = 0, int size = 6)
        {
            List<Level> levels = new List<Level>();
            
             string url = String.Format("https://api.megamanmaker.com/level/search?orderby={0}&orderdir={1}&page={2}&size={3}", 
                 order.ToString(),
                 orderDirection.ToString(), 
                 page,
                 size);
            WebRequest request = WebRequest.Create(url);
            Stream requestStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(requestStream);

            dynamic data = JObject.Parse(objReader.ReadLine());

            foreach(var x in data.items)
            {                
                int aid = x.authorId;
                string aname = x.authorName;
                int aicon = x.authorIcon;
                Author author = new Author(aid, aname, aicon);

                int lid = x.id;
                int lboss = x.boss;
                string lname = x.name;
                DateTime date = x.created;
                int downloads = x.downloads;
                int llikes = x.likes;
                int ldislikes = x.dislikes;
                JTokenReader jtoken = new JTokenReader(x.difficulty); 
                double? ldifficulty = jtoken.ReadAsDouble();
                Level level = new Level(lid, lname, ldifficulty, llikes, ldislikes, lboss, author,date,downloads);

                levels.Add(level);
            }

            return levels;
        }

        /// <summary>
        /// Gets a paginated list of levels that have a search term in their name.
        /// </summary>
        /// <param name="searchTerm">A string representing a search term.</param>
        /// <param name="page">An int representing the page you are requesting.</param>
        /// <param name="size">An int representing the number of levels in a page.</param>
        /// <returns></returns>
        public List<Level> GetLevelsBySearch(string searchTerm, int page = 0, int size = 6)
        {
            List<Level> levels = new List<Level>();

            string url = String.Format("https://api.megamanmaker.com/level/search?search={0}&page={1}&size={2}",
                searchTerm,
                page,
                size);
            WebRequest request = WebRequest.Create(url);
            Stream requestStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(requestStream);

            dynamic data = JObject.Parse(objReader.ReadLine());

            foreach (var x in data.items)
            {
                int aid = x.authorId;
                string aname = x.authorName;
                int aicon = x.authorIcon;
                Author author = new Author(aid, aname, aicon);

                int lid = x.id;
                int lboss = x.boss;
                string lname = x.name;
                DateTime date = x.created;
                int downloads = x.downloads;
                int llikes = x.likes;
                int ldislikes = x.dislikes;
                JTokenReader jtoken = new JTokenReader(x.difficulty);
                double? ldifficulty = jtoken.ReadAsDouble();
                Level level = new Level(lid, lname, ldifficulty, llikes, ldislikes, lboss, author,date,downloads);

                levels.Add(level);
            }

            return levels;
        }

        /// <summary>
        ///     Gets a single level by it's ID
        /// </summary>
        /// <param name="levelId">An integer representing the level id.</param>
        /// <returns>A single level.</returns>
        public Level GetLevel(int levelId)
        {
            string url = String.Format("https://api.megamanmaker.com/level/{0}", levelId);

            WebRequest request = WebRequest.Create(url);
            Stream requestStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(requestStream);
            dynamic data = JObject.Parse(objReader.ReadLine());

            int aid = data.authorId;
            string aname = data.authorName;
            int aicon = data.authorIcon;
            Author author = new Author(aid, aname, aicon);

            int lid = data.id;
            int lboss = data.boss;
            string lname = data.name;
            DateTime date = data.created;
            int downloads = data.downloads;
            int llikes = data.likes;
            int ldislikes = data.dislikes;
            JTokenReader jtoken = new JTokenReader(data.difficulty);
            double? ldifficulty = jtoken.ReadAsDouble();
            Level level = new Level(lid, lname, ldifficulty, llikes, ldislikes, lboss, author,date,downloads);

            return level;
        }

        public Record GetLevelRecord(int levelId)
        {
            string url = String.Format("https://megamaker.webmeka.io/api/getRecordHolder/{0}", levelId);

            WebRequest request = WebRequest.Create(url);
            Stream requestStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(requestStream);
            dynamic data = JObject.Parse(objReader.ReadLine());

            int levelid = 0;
            bool exists = false;
            bool deleted = false;
            bool hasRecord = false;
            int bestTime = 0;
            string bestTimeString = String.Empty;
            string recordHolder = String.Empty;
            int numberOfPlayers = 0;


            levelid = data.levelId;
            exists = data.levelExists;
            if (exists)
            {
                deleted = data.levelDeleted == "0" ? false: true ;
                hasRecord = data.levelHasBeatenTimeRecorded;
                bestTime = data.levelBestBeatenTime;
                bestTimeString = data.levelBestBeatenTimeReadable;
                recordHolder = data.levelBestBeatenTimeHolderName;
                numberOfPlayers = data.levelUsersWithRecords;
            }
            Record record = new Record(levelid, exists,deleted,hasRecord,bestTime,bestTimeString,recordHolder,numberOfPlayers);

            return record;
        }

        /// <summary>
        /// Gets an Author by it's ID
        /// </summary>
        /// <param name="authorId">An int representing the ID of an of author.</param>
        /// <returns>An author.</returns>
        //public Author GetAuthor(int authorId)
        //{
        //    //string url = FormattableString.Invariant($"https://api.megamanmaker.com/level/{levelId}");
        //    //WebRequest request = WebRequest.Create(url);
        //    //Stream requestStream = request.GetResponse().GetResponseStream();

        //    //StreamReader objReader = new StreamReader(requestStream);
        //    //dynamic data = JObject.Parse(objReader.ReadLine());

        //    //int aid = data.authorId;
        //    //string aname = data.authorName;
        //    //int aicon = data.authorIcon;
        //    //Author author = new Author(aid, aname, aicon);

        //    //return author;
        //    return new Author();
        //}

        /// <summary>
        /// Returns all levels associated under an author.
        /// </summary>
        /// <param name="authorId">An int representing the ID of an author.</param>
        /// <returns>A List of Levels.</returns>
        public List<Level> GetLevelsForAuthor(int authorId)
        {
            string url = String.Format("https://api.megamanmaker.com/level/user/{0}", authorId);

            WebRequest request = WebRequest.Create(url);
            Stream requestStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(requestStream);
            dynamic data = JObject.Parse(objReader.ReadLine());

            int aid = data.levels[0].authorId;
            string aname = data.levels[0].authorName;
            int aicon = data.levels[0].authorIcon;
            Author author = new Author(aid, aname, aicon);

            List<Level> levels = new List<Level>();

            foreach (var dlevel in data.levels)
            {
                int lid = dlevel.id;
                int lboss = dlevel.boss;
                string lname = dlevel.name;
                DateTime date = dlevel.created;
                int downloads = dlevel.downloads;
                int llikes = dlevel.likes;
                int ldislikes = dlevel.dislikes;
                JTokenReader jtoken = new JTokenReader(dlevel.difficulty);
                double? ldifficulty = jtoken.ReadAsDouble();
                Level level = new Level(lid, lname, ldifficulty, llikes, ldislikes, lboss, author, date, downloads);
                levels.Add(level);
            }
            return levels;
        }
    }
}
