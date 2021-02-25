using System;
using System.Collections.Generic;
using System.Text;

namespace Maker
{
    public class Author
    {
        #region Properties

        private int Id;
        private string Name;
        private int Icon;

        #endregion Properties

        #region Constructors

        public Author() { }

        public Author(int id, string name, int icon)
        {
            this.Id = id;
            this.Name = name;
            this.Icon = icon;
        }

        #endregion Constructors

        #region Getters

        public int GetId()
        {
            return this.Id;
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetIcon()
        {
            return this.Icon;
        }

        #endregion Getters

        #region Setters

        public void SetId(int id)
        {
            this.Id = id;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetIcon(int icon)
        {
            this.Icon = icon;
        }

        #endregion

    }
}
