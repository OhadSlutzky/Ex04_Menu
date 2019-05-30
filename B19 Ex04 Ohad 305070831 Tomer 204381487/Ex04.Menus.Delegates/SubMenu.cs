using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class SubMenu : MenuItem
    {
        protected List<MenuItem> m_Menu = null;

        public SubMenu(string i_Title) : base(i_Title)
        {
            m_Menu = new List<MenuItem>();
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
            int i = 1;

            Console.WriteLine("-------{0}-------", m_Title);

            foreach (MenuItem menuItem in m_Menu)
            {
                Console.WriteLine("{0}.{1}", i, menuItem.Title);
                i += 1;
            }

            Console.WriteLine("0.Back");
        }

        public void GetUserChosenAction()
        {
            int userChoiceOfAction = 0;
            string userChoiceOfActionString;
            Console.WriteLine("Please enter the action you want to choose:");
            userChoiceOfActionString = Console.ReadLine();

            try
            {
                int.Parse(userChoiceOfActionString);

                if (InputInRange(userChoiceOfAction))
                {
                    if (m_Menu[userChoiceOfAction] is Function)
                    {
                        (m_Menu[userChoiceOfAction] as Function).Invoke();
                    }
                    else if (m_Menu[userChoiceOfAction] is SubMenu)
                    {
                        Console.Clear();
                        (m_Menu[userChoiceOfAction] as SubMenu).PrintMenu();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Please choose from the given options ! ! !");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private bool InputInRange(int i_UserChoiceOfAction)
        {
            return i_UserChoiceOfAction >= 0 && i_UserChoiceOfAction <= m_Menu.Count;
        }
    }

}
