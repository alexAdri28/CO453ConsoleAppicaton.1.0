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
    //constants(grade bandaries)
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
        private void DisplayMenu()
        {
            throw new NotImplementedException();
        }
        ///<summary>
        ///
        ///</summary>
        private void InputMarks()
        {
            throw new NotImplementedException();
        }
        ///<summary>
        ///
        ///</summary>
        private void OutputMarks()
        {
            throw new NotImplementedException();

        }
        ///<summary>
        ///
        ///</summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= 0 && mark < lowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= lowestGradeD && mark < lowestGradeC)
            {
                return Grades.D;
            }
            else if (mark >= lowestGradeC && mark < lowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= lowestGradeB && mark < lowestGradeA)
            {
                return Grades.B;

            }
            else if (mark >= lowestGradeA && mark < highestMark)
            {
                return Grades.A;
            }
            return Grades.F;
        }
       ///<summary>
       ///
       ///</summary>
       public void CalculateStats()
        {
            double total = 0;
            Minimum = highestMark;
            Maximum = 0;

            foreach(int mark in Marks)
            {
                total = total + mark;
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;

            }
            Mean = total / Marks.Length;

        }
        public void CalculateGradesProfile()
        { 
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }
            foreach(int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }

        }
    }
}






               


