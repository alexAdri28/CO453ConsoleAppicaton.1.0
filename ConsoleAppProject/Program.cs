 using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Alex Gordillo Adriano 11/03/2021
    /// </summary>
    public static class Program
    {
        private static DistanceConverter converter = new DistanceConverter();

        private static BMI Calculator = new BMI();
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            string choice = Console.ReadLine();
            string[] choices = { " Distance Converter ", " BMI Calculator ","Students Grades" };

            int choiceNo = ConsoleHelper.SelectChoice(choices);

            if (choiceNo == 1)
            {
                converter.ConvertDistance();
            }
            if (choiceNo == 2)
            {
                Calculator.OutputUnits();
            }
            if (choiceNo == 3)
            {
                
               
            }
        }




    }
}