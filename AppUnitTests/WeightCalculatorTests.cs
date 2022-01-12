using App;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class WeightCalculatorTests
    {
        // Given_When_Then
        [TestMethod]
        [Description("this test is about checking if Ideal Body Weight is" +
                     " 72.5 When Gander Male and Height 180 cm")]
        [Owner("AMK")]
        [TestCategory("WeightCategory")]
        [Priority(1)]
        [Timeout(3000)]

        public void GetIdealBodyWeight_WithGanderM_And_Height_180_Return_72_5()
        {
            // Arrange
            WeightCalculator sut = new WeightCalculator(null, 180, 'm');
            // Act
            double Actual = sut.GetIdealBodyWeight(sut.Gander.Value, sut.Height.Value);
            double Exptected = 72.5;
            // Assert
            Assert.AreEqual(Actual, Exptected);
        }
        [TestMethod]
        public void GetIdealBodyWeight_WithGanderW_And_Height_180_Return_65()
        {
            // Arrange
            WeightCalculator sut = new WeightCalculator(null, 180, 'w');
            // Act
            double Actual = sut.GetIdealBodyWeight(sut.Gander.Value, sut.Height.Value);
            double Exptected = 65;
            // Assert
            Assert.AreEqual(Actual, Exptected);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIdealBodyWeight_WithBadGander_And_Height_180_Throw_Exception()
        {
            // Arrange
            WeightCalculator sut = new WeightCalculator(null, 180, 's');
            // Act
            double Actual = sut.GetIdealBodyWeight(sut.Gander.Value, sut.Height.Value);
            double Exptected = 0;
            // Assert
            Assert.AreEqual(Actual, Exptected);
        }

        [TestMethod]
        [Ignore]
        public void Asser_Test()
        {
            Assert.AreEqual(100, 90 + 10);
        }

        [TestMethod]
        public void Fluent_Assert()
        {
            //string Name = "Ahmed";
            //Name.Should().StartWith("A").And.EndWith("d");

            //int Num = 10;
            //Num.Should().BeGreaterThanOrEqualTo(10);

            IEnumerable<string> Names = new List<string>() { "Ahmed", "Ali" };
            Names.Should()
                .NotBeEmpty()
                .And.HaveCount(2)
                .And.HaveCountGreaterThan(1);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_withGoodInputs_Return_Correct_Result()
        {
            WeightCalculator weightCalculator = new WeightCalculator(new FakeWeightRepository(), new double(), new char());
            List<double> Actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75, 74 };
            CollectionAssert.AreEqual(expected, Actual);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSourc_USing_Moq()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                new WeightCalculator(null,175,'w'),
                new WeightCalculator(null,167,'m')
            };
            Mock<IDataRepository> repo = new Mock<IDataRepository>();
            repo.Setup(w => w.GetWeights()).Returns(weights);
            WeightCalculator calculator = new WeightCalculator(repo.Object, null, null);
            IEnumerable<double> Actual = calculator.GetIdealBodyWeightFromDataSource();
            double[] Expected = { 62.5, 62.75 };
            Actual.Should().Equal(Expected);
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSourc_USing_FakeItEasy()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                new WeightCalculator(null,175,'w'),
                new WeightCalculator(null,167,'m')
            };
            IDataRepository repo = A.Fake<IDataRepository>();
            A.CallTo(() => repo.GetWeights()).Returns(weights);
            WeightCalculator calculator = new WeightCalculator(repo, null, null);
            IEnumerable<double> Actual = calculator.GetIdealBodyWeightFromDataSource();
            double[] Expected = { 62.5, 62.75 };
            Actual.Should().Equal(Expected);
        }

        [DataTestMethod]
        [DataRow(175, 'w', 62.5)]
        [DataRow(167, 'm', 62.75)]
        [DataRow(182, 'm', 74)]
        public void Working_With_Data_Driven_Test(double height, char gander, double expected)
        {
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Gander = gander
            };
            var Actual = weightCalculator.GetIdealBodyWeight(gander, height);
            Actual.Should().Be(expected);
        }

        public static List<object[]> TestCases()
        {
            return new List<object[]>
            {
              new object[] { 175,'w',62.5 },
              new object[] { 167, 'm',62.75 },
              new object[] { 182, 'm',74 },
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(TestCases), DynamicDataSourceType.Method)]
        public void Dynamic_Test(double height, char gander, double expected)
        {
            WeightCalculator weight = new WeightCalculator()
            {
              Height = height,
              Gander = gander
            };
            var Actual = weight.GetIdealBodyWeight(gander,height);
            Actual.Should().Be(expected);
        }
        //TDD Test Driven Development
        [TestMethod]
        public void Validate_With_Bad_Gander_Return_False()
        {
            WeightCalculator weightCalculator = new WeightCalculator();
            weightCalculator.Gander = 't';
            bool Actual = weightCalculator.Validate();
            Actual.Should().BeFalse();
        }
    }
}