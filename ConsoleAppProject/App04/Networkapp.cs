using System;
using System.Collections.Generic;
using ConsoleAppProject.Helpers;
using System.Text;


namespace ConsoleAppProject.App04
{
    public class Networkapp
    { 
        public  void  DisplayMenu()
        {
            ConsoleHelper.OutputHeading("Alex's News Feed");
            string[] choices = new string[]
            {
                "Post Message" ,"Post Image ","" +
                "Display  All  Posts","Quit"
            };
            bool wantToQuit = false;

            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choices)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4: wantToQuit = true; break;

                }

            } while (!wantToQuit);
        }

        private void DisplayAll()
        {
            throw new NotImplementedException();
        }

        private void PostImage()
        {
            throw new NotImplementedException();
        }

        private void PostMessage()
        {
            throw new NotImplementedException();
        }
    }
}
