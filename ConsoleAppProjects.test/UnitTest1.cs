using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
namespace ConsoleAppProjects.test
{
    [TestClass]
    public class TestDistanceConverter
    {
        [TestMethod]
        public void TestMilesToFeet()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.MILES;
            converter.ToUnit = DistanceConverter.FEET;

            converter.FromDistance = 1.0;
            converter.CalculateDistance();

            double expectedDistance = 5280;

            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }
        [TestMethod]
        public void TestFeetToMiles()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.FEET;
            converter.ToUnit = DistanceConverter.MILES;

            converter.FromDistance = 1.0;
            converter.CalculateDistance();

            double expectedDistance = 0.0001893939393939394;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestMilestoMetres()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.MILES;
            converter.ToUnit = DistanceConverter.METRES;

            converter.FromDistance = 1.0;
            converter.CalculateDistance();

            double expectedDistance = 1609.34;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestMetrestoFeet()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.METRES;
            converter.ToUnit = DistanceConverter.FEET;

            converter.FromDistance = 1.0;
            converter.CalculateDistance();

            double expectedDistance = 3.28084;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
    }
}
[TestClass]

public class TestBMICalculator
{
    [TestMethod]

    public void TestunderweightBMIMetric()
    {
        BMI Calculator = new BMI();

        Calculator.weight = BMI.Pounds;
        Calculator.height = BMI.feet;

        Calculator.bmiResult = 18.5;
        Calculator.CalculateBMI();

        double expectedCalculation = 18.50;

        Assert.AreEqual(expectedCalculation, Calculator.bmiResult);

    }
}
