using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// BMI Calculator (Body Mass Index) is a measure that uses your height and weight to work out if your weight is healthy. 
    /// </summary>
    /// <author>
    /// Alex Gordillo Adriano version 0.6
    /// </author>
    public class BMI
    {
        public const string METRIC = "METRIC"; 
        public const string IMPERIAL = "IMPERIAL";
        public const string FEET = "feet";
        public const string POUNDS = "pounds";

        public double weight { get; set; }
        public double height { get; set; } 

        public string SelectedUnit { get; set; }

        public double bmiResult { get; set; }
        public static double Pounds { get; set; }

        public static double feet { get; set; }

        public string[] MenuChoices = { METRIC, IMPERIAL};
        public void OutputUnits() 
        {
            ConsoleHelper.OutputHeading("\tBMI Calculator\n\t By Alex Adriano ");
            ConsoleHelper.OutputIntroduction(" The Body Mass Index is a measure that uses your height and weight to work out if your weight is healthy. ");
            ConsoleHelper.OutputMenu(MenuChoices);

           
        }

        public string GetUnit()
        {
            SelectedUnit = Console.ReadLine().ToUpper();
            return SelectedUnit;
        }

        public double GetWeight()
        {
            if (SelectedUnit == METRIC)
            {
                Console.WriteLine(" You have chosen metric - please enter the weight in KGs:");
            }

            if (SelectedUnit == IMPERIAL)
            {
                Console.WriteLine(" You have chosen Imperial - Please enter weight In pounds");
            }
    
                weight = Convert.ToDouble(Console.ReadLine());
            return weight;
        }
        public double GetHeight()
        {
            if (SelectedUnit == METRIC)
            {
                Console.WriteLine("please enter the height in CMs:");
            }
            
            if (SelectedUnit == IMPERIAL)
            {
                Console.WriteLine("please enter the height in  Inches");
            }
            height = Convert.ToDouble(Console.ReadLine());
            return height;
        }
        public void CalculateBMI()


        {
            if (SelectedUnit == METRIC)
            {
                bmiResult = (weight / height / height) * 10000;

            }
            else if (SelectedUnit == IMPERIAL)
            {
                bmiResult = (weight / height / height) * 703;
            }
            else Console.Write("Invalid choice");

          
            
        }
        private void OutputMessage()
        {
            if (bmiResult < 18.50)
            {
                Console.WriteLine("You are Underweight - You are potentially at risk seek contact your GP for adv");
            }
            else if ((bmiResult >= 18.5) && (bmiResult < 24.9))
            {
                Console.WriteLine("You are normal weight - as classified by the World Health Organisation  ");
            }
            else if ((bmiResult >= 25.0) && (bmiResult < 29.9))
            {
                Console.WriteLine("You are Overweight - as classified by the World Health Organisation  ");
            }
            else if ((bmiResult >= 30.0) && (bmiResult < 34.9))
            {
                Console.WriteLine("You have been classed as Obese class 1 - you are at risk");
            }
            else if ((bmiResult >= 35.0) && (bmiResult < 39.9))
            {
                Console.WriteLine("You have been classed as Obese class 2 - you are at serious risk ");
            }
            else if (bmiResult > 40 )
            {
                Console.WriteLine("You have been classed as obese class 3 - You are at severe risk - " +
                  "immediately seek medical advice ");
            }
        }


            public void OutputResult()
        {
            Console.WriteLine(SelectedUnit + " " + bmiResult);
            OutputMessage();
            Console.WriteLine(" Note - if you are Black, Asian or an ethnic minority you have a much higher risk" +
                 " Adults at 23.0 or more are at risk. ");
        }
    }
}