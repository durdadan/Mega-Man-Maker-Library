using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker
{
    public class Record
    {
        #region Properties

        public int LevelId { get; set; }
        public bool Exists { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasRecord { get; set; }
        public int BestTimeMiliseconds { get; set; }
        public string BestTimeReadable { get; set; }
        public string RecordHolder { get; set; }
        public int NumberOfPlayers { get; set; }

        #endregion properties

        #region Constructors
        
        /// <summary>
        /// Basic Constructor
        /// </summary>
        public Record()
        {
        }

        /// <summary>
        /// Constructs a populated Record
        /// </summary>
        /// <param name="id">Level Id</param>
        /// <param name="levelExists">A boolean representing if a level exists in WebMeka or not.</param>
        /// <param name="isDeleted">A boolean representing if a level is deleted or active.</param>
        /// <param name="hasRecord">A boolean representing if a level has a record currently.</param>
        /// <param name="bestTime">An integer representing the best time of the level in miliseconds.</param>
        /// <param name="bestTimeReadable">A string representing the human readable format of the best time.</param>
        /// <param name="recordHolder">A string with the current best record holder's username.</param>
        /// <param name="numberOfPlayers">An integer representing the number of users that have a time registered on WebMeka</param>
        public Record(int id, bool levelExists, bool isDeleted, bool hasRecord, int bestTime, string bestTimeReadable, string recordHolder, int numberOfPlayers)
        {
            this.LevelId = id;
            this.Exists = levelExists;
            this.IsDeleted = isDeleted;
            this.HasRecord = hasRecord;
            this.BestTimeMiliseconds = bestTime;
            this.BestTimeReadable = bestTimeReadable;
            this.RecordHolder = recordHolder;
            this.NumberOfPlayers = numberOfPlayers;
        }

        #endregion

        #region Methods

       
        #endregion
    }
}

