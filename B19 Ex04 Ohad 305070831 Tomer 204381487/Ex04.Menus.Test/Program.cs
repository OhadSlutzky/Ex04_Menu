using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            Tester tester = new Tester();
            MenuItem myMenu = new MainMenu("Main Menu");
            (myMenu as MainMenu).AddMenuItem(new Function("Exit"));
            (myMenu as MainMenu).AddMenuItem(new SubMenu("Show Date/Time", (myMenu as MainMenu)));
            (myMenu as MainMenu).AddMenuItem(new SubMenu("Version and Digits", (myMenu as MainMenu)));

            ((myMenu as MainMenu).Menu[1] as SubMenu).AddMenuItem(new Function("Back"));
            ((myMenu as MainMenu).Menu[1] as SubMenu).AddMenuItem(new Function("Show Date"));
            ((myMenu as MainMenu).Menu[1] as SubMenu).AddMenuItem(new Function("Show Time"));
            ((myMenu as MainMenu).Menu[2] as SubMenu).AddMenuItem(new Function("Back"));
            ((myMenu as MainMenu).Menu[2] as SubMenu).AddMenuItem(new Function("Count Digits"));
            ((myMenu as MainMenu).Menu[2] as SubMenu).AddMenuItem(new Function("Show Version"));

            ((myMenu as MainMenu).Menu[0] as Function).AddClickedListener(tester);
            (((myMenu as MainMenu).Menu[1] as SubMenu).Menu[0] as Function).AddClickedListener(tester);
            (((myMenu as MainMenu).Menu[1] as SubMenu).Menu[1] as Function).AddClickedListener(tester);
            (((myMenu as MainMenu).Menu[1] as SubMenu).Menu[2] as Function).AddClickedListener(tester);
            (((myMenu as MainMenu).Menu[2] as SubMenu).Menu[0] as Function).AddClickedListener(tester);
            (((myMenu as MainMenu).Menu[2] as SubMenu).Menu[1] as Function).AddClickedListener(tester);
            (((myMenu as MainMenu).Menu[2] as SubMenu).Menu[2] as Function).AddClickedListener(tester);

            while(true)
            {
                (myMenu as Interfaces.MainMenu).PrintMenu();
            }
        }
    }

    class Tester : IClicked
    {
        public void MethodInvoke(string i_ItemTitle)
        {
            switch (i_ItemTitle)
            {
                case "Show Date":
                    ShowDate();
                    break;

                case "Show Time":
                    ShowTime();
                    break;

                case "Count Digits":
                    CountDigits();
                    break;

                case "Show Version":
                    ShowVersion();
                    break;
                case "Exit":
                    ExitSequence();
                    break;
            }
        }

        private void ExitSequence()
        {
            Console.WriteLine("BYE BYE!");
            System.Threading.Thread.Sleep(1000);
            System.Environment.Exit(0);
        }

        private void ShowDate()
        {
            Console.WriteLine(DateTime.Today.ToShortDateString());
        }

        private void ShowTime()
        {
            Console.WriteLine("{0:HH:mm:ss tt}", DateTime.Now);
        }

        private void CountDigits()
        {
            string userInput = null;
            int numOfDigits = 0;

            Console.WriteLine("Please enter a sentence:");
            userInput = Console.ReadLine();

            foreach(char c in userInput)
            {
                if(char.IsDigit(c))
                {
                    numOfDigits += 1;
                }
            }

            Console.WriteLine("The sentence you entered contains {0} digits!", numOfDigits);
        }

        private void ShowVersion()
        {
            Console.WriteLine("Version: 19.2.4.32");
        }
    }
}
