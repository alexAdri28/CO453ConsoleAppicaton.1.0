using System;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject
{
    public static class ConsoleHelper
    {

        public static void OutputHeading(String title)
        {
            Console.WriteLine(" .................................. ");
            Console.WriteLine($"           {title}                  ");
            Console.WriteLine("       by Alex Adriano                ");
            Console.WriteLine(" .................................. ");
        }
        public static void OutputIntroduction(string introduction)
        {
            Console.WriteLine(" ==== Introduction ==== ");
            Console.WriteLine(introduction);
        }
        public static void OutputMenu(string[] choices)
        {
            int choiceNo = 0;
            foreach (string choice in choices)
            {
                choiceNo++;
                Console.WriteLine(choiceNo + ". " + choice);
            }
        }
        public static int SelectChoice(string[] choices)
        {
            int choiceNo = 0;
            foreach (string choice in choices)
            {
                choiceNo++;
                Console.WriteLine($"  {choiceNo}. {choice}");
            }
            // get the users choice 
            Console.WriteLine("please enter your choice > ");

            string value = Console.ReadLine();

            choiceNo = Convert.ToInt32(value);
                
            return choiceNo;
           




        }

   
    }
   


}



