using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : SubMenu
    {
        public MainMenu(string i_Title) : base(i_Title) { }

        public override void PrintMenu()
        {
            int i = 1;

            foreach (MenuItem menuItem in m_Menu)
            {
                Console.WriteLine("{0}.{1}", i, menuItem.Title);
                i += 1;
            }

            Console.WriteLine("0.Exit");
        }
    }
}
