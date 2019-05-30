using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public interface IClicked
    {
        void MethodInvoke(string i_ItemTitle);
    }

    public class MainMenu : SubMenu
    {
        public MainMenu(string i_Title) : base(i_Title, null) { }

        public override void PrintMenu()
        {
            int i = 1;

            Console.WriteLine("-------{0}-------", m_Title);

            foreach (MenuItem menuItem in m_Menu)
            {
                if (menuItem.Title.Equals("Exit") == false)
                {
                    Console.WriteLine("{0}.{1}", i, menuItem.Title);
                    i += 1;
                }
            }

            Console.WriteLine("0.Exit");

            GetUserChosenAction();
        }
    }
}
