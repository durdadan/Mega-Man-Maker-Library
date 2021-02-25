using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Maker
{
    public class Api
    {
        /// <summary>
        ///     Gets a paginated list of 5 levels.
        /// </summary>
        /// <param name="page">An integer representing the page of requested levels.</param>
        /// <param name="orderDirection">A string representing the orderby direction.</param>
        /// <returns>A List of levels.</returns>
        public List<Level> GetLevels(int page = 0, string orderDirection = "desc")
        {
            List<Level> levels = new List<Level>();
            
             string url = String.Format("https://api.megamanmaker.com/level/search?orderby=date&orderdir={0}&page={1}&size=10", orderDirection, page);
            // string url ="https://api.mocki.io/v1/9792c441";
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
                int llikes = x.likes;
                int ldislikes = x.dislikes;
                    JTokenReader jtoken = new JTokenReader(x.difficulty); 
                double? ldifficulty = jtoken.ReadAsDouble();
                Level level = new Level(lid, lname, ldifficulty, llikes, ldislikes, lboss, author);

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
            int llikes = data.likes;
            int ldislikes = data.dislikes;
            JTokenReader jtoken = new JTokenReader(data.difficulty);
            double? ldifficulty = jtoken.ReadAsDouble();
            Level level = new Level(lid, lname, ldifficulty, llikes, ldislikes, lboss, author);

            return level;
        }

        /// <summary>
        /// Gets an Author by it's ID
        /// </summary>
        /// <param name="authorId">An int representing the ID of an of author.</param>
        /// <returns>An author.</returns>
        public Author GetAuthor(int authorId)
        {
            //string url = FormattableString.Invariant($"https://api.megamanmaker.com/level/{levelId}");
            //WebRequest request = WebRequest.Create(url);
            //Stream requestStream = request.GetResponse().GetResponseStream();

            //StreamReader objReader = new StreamReader(requestStream);
            //dynamic data = JObject.Parse(objReader.ReadLine());

            //int aid = data.authorId;
            //string aname = data.authorName;
            //int aicon = data.authorIcon;
            //Author author = new Author(aid, aname, aicon);

            //return author;
            return new Author();
        }

        /// <summary>
        /// Returns all levels associated under an author.
        /// </summary>
        /// <param name="authorId">An int representing the ID of an author.</param>
        /// <returns>A List of Levels.</returns>
        public List<Level> GetLevelsForAuthor(int authorId)
        {
            return new List<Level>();
        }
    }
}
