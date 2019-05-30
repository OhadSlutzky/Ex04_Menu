using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        protected List<MenuItem> m_Menu = null;
        protected SubMenu m_PreviousMenu;

        public SubMenu(string i_Title, SubMenu i_PreviousMenu) : base(i_Title)
        {
            m_Menu = new List<MenuItem>();
            m_PreviousMenu = i_PreviousMenu;
        }

        public List<MenuItem> Menu
        {
            get
            {
                return m_Menu;
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem != null)
            {
                m_Menu.Add(i_MenuItem);
            }
            else
            {
                throw new ArgumentNullException("The item you tried to add was null ! ! !");
            }
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            m_Menu.Remove(i_MenuItem);
        }

        public virtual void PrintMenu()
        {
            Console.Clear();
            int i = 1;

            Console.WriteLine("-------{0}-------", m_Title);
            foreach (MenuItem menuItem in m_Menu)
            {
                if(menuItem.Title.Equals("Back") == false)
                {
                    Console.WriteLine("{0}.{1}", i, menuItem.Title);
                    i += 1;
                }
            }

            Console.WriteLine("0.Back");

            GetUserChosenAction();
        }

        public void GetUserChosenAction()
        {
            int userChoiceOfAction = 0;
            string userChoiceOfActionString;
            Console.WriteLine("Please enter the action you want to choose:");
            userChoiceOfActionString = Console.ReadLine();

            try
            {
                userChoiceOfAction = int.Parse(userChoiceOfActionString);

                if (InputInRange(userChoiceOfAction))
                {
                    if (m_Menu[userChoiceOfAction] is Function)
                    {
                        if(m_Menu[userChoiceOfAction].Title.Equals("Back"))
                        {
                            m_PreviousMenu.PrintMenu();
                        }

                        (m_Menu[userChoiceOfAction] as Function).Invoke();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        PrintMenu();
                    }
                    else if (m_Menu[userChoiceOfAction] is SubMenu)
                    {
                        Console.Clear();
                        (m_Menu[userChoiceOfAction] as SubMenu).PrintMenu();
                    }
                }
                else
                {
                    throw new Exception("Please choose from the given options ! ! !");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                System.Threading.Thread.Sleep(2000);
                PrintMenu();
            }
        }

        private bool InputInRange(int i_UserChoiceOfAction)
        {
            return i_UserChoiceOfAction >= 0 && i_UserChoiceOfAction <= m_Menu.Count;
        }
    }
}
