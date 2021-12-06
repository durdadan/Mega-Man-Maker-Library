using System;
using System.Collections.Generic;
using System.Text;

namespace Maker
{
    public class Author
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int Icon { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public Author() { }

        /// <summary>
        /// Constructs an Author
        /// </summary>
        /// <param name="id">An integer representing a user id.</param>
        /// <param name="name">A string representing a user name.</param>
        /// <param name="icon">An integer representing an image icon.</param>
        public Author(int id, string name, int icon)
        {
            this.Id = id;
            this.Name = name;
            this.Icon = icon;
        }

        #endregion Constructors

    }
}
