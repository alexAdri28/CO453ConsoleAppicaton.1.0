using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public const int lowestMark = 0;
        public const int lowestGradeD = 40;
        public const int lowestGradeC = 50;
        public const int lowestGradeB = 60;
        public const int lowestGradeA = 70;
        public const int highestMark = 100;
        
        //Properties 
        public string[] Students { get; set; }

        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
       public double Mean { get; set; }
       public int Minimum { get; set; }
        public int Maximum { get; set; }
        /// <summary>
        /// Class Constructor set up an array of Students
        /// </summary>

        public StudentGrades()
        {
            Students = new string[]
            {
                "Kevin","Maria","Ellie","Georgina","Alex","Oliver",
                "Sandra","Roman","Daniel","David"
            };
            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }
        /// <summary>
        ///  Main mothod is the StudentGrade class
        /// </summary>
        public void Main()
        {
            string[] Choices = new string[]
            {
                "Input Marks","Output Marks","Output Stats", "Output Grades"
            };
            bool finished = false;
            do
            {
                Console.WriteLine();
                switch(ConsoleHelper.SelectChoice(Choices))
                {
                    case 1:
                        InputMarks();
                        break; 
                    case 2:
                        OutputMarks();
                        break;
                    case 3:
                        OutputStats();
                        break;
                    case 4:
                        CalculateGradeProfile();
                        OutGradeProfile();
                        break;
                    case 5:
                        Console.WriteLine(@"Now quitting student Grades");
                        finished = true;
                        break;
                    case 6:
                        giveMarksTesting();
                        break;
                    case 7:
                        giveMarksTo(Console.WriteLine(),ConsoleHelper.)
                         break;
                }
            }
        }

         
        public void TestGradesEnumeration()
     {
        Grades grade = Grades.C;

        Console.WriteLine($"Grade = {grade}");
        Console.WriteLine($"Grade No = {(int)grade}");

        Console.WriteLine("\nDiscovered by Andrei!\n");
        var gradeName = grade.GetAttribute<DisplayAttribute>().Name;
        Console.WriteLine($"Grade Name = {gradeName}");

        var gradeDescription = grade.GetAttribute<DescriptionAttribute>().Description;
        Console.WriteLine($"Grade Description = {gradeDescription}");

        string testDescription = EnumHelper<Grades>.GetDescription(grade);
        string testName = EnumHelper<Grades>.GetName(grade);

        Console.WriteLine();
        Console.WriteLine("Discovered by Derek Using EnumHelper\n");
        Console.WriteLine($"Name = {testName}");
        Console.WriteLine($"Description = {testDescription}");


    }
} }


