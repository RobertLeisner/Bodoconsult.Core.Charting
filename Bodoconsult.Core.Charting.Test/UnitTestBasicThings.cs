using System;
using System.Diagnostics;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Util;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Charting.Test
{
    [TestFixture]
    public class UnitTestBasicThings
    {

        const double Tolerance = 0.00000001;

        /// <summary>
        /// Constructor to initialize class
        /// </summary>
        public UnitTestBasicThings()
        {

        }


        /// <summary>
        /// Runs in front of each test method
        /// </summary>
        [SetUp]
        public void Setup()
        {


        }

        /// <summary>
        /// Cleanup aft test methods
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

            
        }


        [Test]
        public void TestMappingChartItemData()
        {

            var x = new ChartItemData {XValue = 1};


            var y = (IChartItemData) x;


            var z = (ChartItemData) y;



        }


        [Test]
        public void TestScalinglineChartsMechanism()
        {
            //Arrange
            var max = 10.17;
            var min = 0.0;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);

            Assert.IsTrue(max - 11.0 <Tolerance);
            Assert.IsTrue(min - 0.0 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 1) < Tolerance);
        }

        [Test]
        public void TestScalinglineChartsMechanism1()
        {
            //Arrange
            var max = 1.47;
            var min = 0.76;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);

            Assert.IsTrue(max - 1.5 < Tolerance);
            Assert.IsTrue(min - 0.7 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 0.1) < Tolerance);
        }


        [Test]
        public void TestScalinglineChartsMechanism1_SmallValues()
        {
            //Arrange
            var max = 0.00004556;
            var min = 0.000003;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);


            Assert.IsTrue(max > 0 && max - 0.00005 < Tolerance);
            Assert.IsTrue(min - 0.00000 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 0.00001) < Tolerance);


        }


        [Test]
        public void TestScalinglineChartsMechanism1_SmallValuesMinus()
        {
            //Arrange
            var max = -0.00004556;
            var min = -0.000003;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);


            Assert.IsTrue(max < 0 && max + 0.00003 < Tolerance);
            Assert.IsTrue(min + 0.000003 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 0.00001) < Tolerance);


        }

        [Test]
        public void TestScalinglineChartsMechanism1_SmallValuesOneNull()
        {
            //Arrange
            var max = 0.00004556;
            var min = 0.00000;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);


            Assert.IsTrue(max > 0 && max - 0.00005 < Tolerance);
            Assert.IsTrue(min > -0.00000001 && min - 0.0 < Tolerance);
           // Assert.IsTrue(Math.Abs(interval - 0.00001) < Tolerance);


        }


        [Test]
        public void TestScalinglineChartsMechanism1_SmallValuesOneNullMinus()
        {
            //Arrange
            var max = 0.00000;
            var min = -0.00004556;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);


            Assert.IsTrue(max >= 0 && max - 0.0 < Tolerance);
            Assert.IsTrue(min + 0.00005 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 0.00001) < Tolerance);


        }


        [Test]
        public void TestScalinglineChartsMechanism1_BigValues()
        {
            //Arrange
            var max = 196.46;
            var min = 101.96;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);


            Assert.IsTrue(max > 0 && max - 200 < Tolerance);
            Assert.IsTrue(min > -0.00000001 && min - 100.0 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 10) < Tolerance);


        }

        [Test]
        public void TestScalinglineChartsMechanism1_SmallValuesOneNullOneOne()
        {
            //Arrange
            var max = 1.00000;
            var min = 0.0;

            // Act
            var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

            //Assert
            Debug.Print("{0:#,##0.000000}", min);
            Debug.Print("{0:#,##0.000000}", max);
            Debug.Print("{0:#,##0.000000}", interval);


            Assert.IsTrue(max >= 0 && max - 1.0 < Tolerance);
            Assert.IsTrue(min + 0.0000 < Tolerance);
            Assert.IsTrue(Math.Abs(interval - 0.1) < Tolerance);


        }

    }
}