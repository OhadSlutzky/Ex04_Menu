using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        protected string m_Title;

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }
    }

}
