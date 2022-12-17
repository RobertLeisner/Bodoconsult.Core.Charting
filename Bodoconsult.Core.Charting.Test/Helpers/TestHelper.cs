using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using Bodoconsult.Core.Charting.Base.Models;
using NUnit.Framework;

namespace Bodoconsult.Core.Charting.Test.Helpers
{
    public static class TestHelper
    {
        private static string _testDataPath;

        public static string TestDataPath
        {
            get
            {

                if (!string.IsNullOrEmpty(_testDataPath)) return _testDataPath;

                var path = new DirectoryInfo(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName).Parent.Parent.Parent.FullName;

                _testDataPath = Path.Combine(path, "TestData");

                if (!Directory.Exists(_testDataPath)) Directory.CreateDirectory(_testDataPath);

                return _testDataPath;
            }
        }

        /// <summary>
        /// Start an app by file name
        /// </summary>
        /// <param name="fileName"></param>
        public static void StartFile(string fileName)
        {

            if (!Debugger.IsAttached) return;

            Assert.IsTrue(File.Exists(fileName));

            var p = new Process {StartInfo = new ProcessStartInfo {UseShellExecute = true, FileName = fileName}};

            p.Start();

        }

        /// <summary>
        /// Load a default style for the charts
        /// </summary>
        /// <param name="chartData"></param>
        /// <param name="highResolution"></param>
        public static void LoadDefaultChartStyle(ChartData chartData, bool highResolution = false)
        {
            //data.ChartStyle.BackGradientStyle = GradientStyle.TopBottom;

            //data.ChartStyle.BackgroundColor = Color.White;

            //data.ChartStyle.BackgroundSecondColor = Color.LightBlue;
            //data.ChartStyle.CopyrightFontSizeDelta = 0.6F;


            var chartStyle = GlobalValues.DefaultTypography().ChartStyle;

            if (highResolution)
            {
                chartStyle.Width = 4500;
                chartStyle.Height = 2781;
                chartStyle.FontSize = 12;
            }

            chartStyle.CopyrightFontSizeDelta = 0.6F;
            chartStyle.BackgroundColor = Color.Transparent;
            //_chartStyle.AxisLineColor = Color.DarkBlue;

            //
            chartData.ChartStyle  = chartStyle;
            chartData.Copyright = "(c) Testfirma";

        }


        public static DataTable GetDataTable(string fileName)
        {
            var path = Path.Combine(TestHelper.TestDataPath, fileName);

            return JsonXmlHelper.GetDataTableFromXml(path);
        }

        /// <summary>
        /// The path where the test results are saved in
        /// </summary>
        public static string TestResultPath => @"c:\temp\";
    }
}