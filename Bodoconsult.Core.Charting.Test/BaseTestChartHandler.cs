// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO;
using System.Runtime.Versioning;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Test.Helpers;
using Bodoconsult.Core.Charting.Util;
using NUnit.Framework;

namespace Bodoconsult.Core.Charting.Test
{
    [SupportedOSPlatform("windows")]
    public abstract class BaseTestChartHandler
    {

        protected bool HighResolution;

        protected bool UseDatabase;


        [Test]
        public void TestStackedBarChart()
        {

            // const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";
            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_Db_StackedBarChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteilswert",
                FileName = fileName,
                ChartType = ChartType.StackedBarChart,

            };

            TestHelper.LoadDefaultChartStyle(data);

            var dt = TestHelper.GetDataTable("StackedBarChart.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestStackedColumnChart()
        {

            //const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_Db_StackedColumnChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteilswert",
                FileName = fileName,
                ChartType = ChartType.StackedColumnChart,

            };

            TestHelper.LoadDefaultChartStyle(data);

            var dt = TestHelper.GetDataTable("StackedColumnChart.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestStackedColumn100Chart()
        {

            // const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_Db_StackedColumn100Chart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteilswert",
                FileName = fileName,
                ChartType = ChartType.StackedColumn100Chart,
            };

            TestHelper.LoadDefaultChartStyle(data);

            var dt = TestHelper.GetDataTable("StackedColumnChart.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestPieChart()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_PieChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.PieChart,
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            TestDataHelper.PieChartSample(UseDatabase, data);



            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestPointChart()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_PointChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Risiko in %",
                YLabelText = "Rendite in %",
                FileName = fileName,
                ChartType = ChartType.PointChart,
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);
            TestDataHelper.PointChartSample(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "0.00";
            data.ChartStyle.YAxisNumberformat = "0.00";

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestPointChartPercent()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_PointChart_Percent.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Risiko",
                YLabelText = "Rendite",
                FileName = fileName,
                ChartType = ChartType.PointChart,

            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            TestDataHelper.PointChartSamplePercent(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "P0";
            data.ChartStyle.YAxisNumberformat = "P0";

            data.PropertiesToUseForChart.Add("XValue");
            data.PropertiesToUseForChart.Add("YValue");

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestBarChart()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_BarChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",

                FileName = fileName,
                ChartType = ChartType.BarChart,

            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            TestDataHelper.BarChartSample(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "0.00";

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestColumnChart()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_ColumnChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {

                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",


                FileName = fileName,
                ChartType = ChartType.ColumnChart,


            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);
            TestDataHelper.BarChartSample(UseDatabase, data);

            data.ChartStyle.YAxisNumberformat = "0.00";

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }

        [Test]
        public void TestLineChart()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_LineChart.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteilwert",
                FileName = fileName,
                ChartType = ChartType.LineChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            TestDataHelper.ChartSample(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "dd.MM.yyyy";

            data.PropertiesToUseForChart.Add("XValue");
            data.PropertiesToUseForChart.Add("YValue1");
            data.PropertiesToUseForChart.Add("YValue2");
            data.PropertiesToUseForChart.Add("YValue3");

            data.LabelsForSeries.Add("Aktien");
            data.LabelsForSeries.Add("Renten");
            data.LabelsForSeries.Add("Liquidität");

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }



        [Test]
        public void TestLineChart_SmallValues()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_LineChart_SmallValues.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.LineChart,

            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);
            TestDataHelper.ChartSampleSmallValues(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "0.0000";
            data.ChartStyle.YAxisNumberformat = "0.0000";

            data.PropertiesToUseForChart.Add("XValue");
            data.PropertiesToUseForChart.Add("YValue1");
            data.PropertiesToUseForChart.Add("YValue2");
            data.PropertiesToUseForChart.Add("YValue3");

            data.LabelsForSeries.Add("Aktien");
            data.LabelsForSeries.Add("Renten");
            data.LabelsForSeries.Add("Liquidität");

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestLineChart_Histogram()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_LineChart_Histogram.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Histogram",
                Copyright = "Testfirma",
                XLabelText = "Klasse",
                YLabelText = "Anzahl",

                FileName = fileName,
                ChartType = ChartType.Histogram
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);
            TestDataHelper.ChartSampleHistogram(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "0.0000%";
            data.ChartStyle.YAxisNumberformat = "0.0000%";

            data.PropertiesToUseForChart.Add("XValue");
            data.PropertiesToUseForChart.Add("YValue1");

            //data.LabelsForSeries.Add("Kumulierter Anteil");


            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestLineChart_Percentages()
        {

            var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_LineChart_Percentages.png");

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.LineChart
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);
            TestDataHelper.ChartSampleSmallValues(UseDatabase, data);

            data.ChartStyle.XAxisNumberformat = "0.0000%";
            data.ChartStyle.YAxisNumberformat = "0.0000%";

            data.PropertiesToUseForChart.Add("XValue");
            data.PropertiesToUseForChart.Add("YValue1");
            data.PropertiesToUseForChart.Add("YValue2");
            data.PropertiesToUseForChart.Add("YValue3");

            data.LabelsForSeries.Add("Aktien");
            data.LabelsForSeries.Add("Renten");
            data.LabelsForSeries.Add("Liquidität");

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        //[Test]
        //public void TestLineChart_XAxisDouble()
        //{

        //    var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_LineChart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData<ChartItemData1>
        //    {
        //        Width = 750,
        //        Height = 550,
        //        Title = "Test portfolio",
        //        DataSource = TestData.ChartSampleDouble(),
        //        Copyright = "Testfirma",
        //        XLabelText = "Anlageklassen",
        //        YLabelText = "Anteil in %",
        //        FileName = fileName,
        //        ChartType = ChartType.LineChart,

        //    };

        //    data.PropertiesToUseForChart.Add("XValue");
        //    data.PropertiesToUseForChart.Add("YValue1");
        //    data.PropertiesToUseForChart.Add("YValue2");
        //    data.PropertiesToUseForChart.Add("YValue3");

        //    data.LabelsForSeries.Add("Aktien");
        //    data.LabelsForSeries.Add("Renten");
        //    data.LabelsForSeries.Add("Liquidität");

        //    var x = new ChartHandler<ChartItemData1>
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    Assert.IsTrue(File.Exists(fileName));

        //}



        //[Test]
        //public void TestStackedColumnChart()
        //{

        //    var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_StackedColumnChart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {

        //        Title = "Test portfolio",
        //        Copyright = "Testfirma",
        //        XLabelText = "Anlageklassen",
        //        YLabelText = "Anteil in %",
        //        DataSource = TestDataHelper.ChartSample(),

        //        FileName = fileName,
        //        ChartType = ChartType.StackedColumnChart,

        //    };

        //    TestHelper.LoadDefaultChartStyle(data, HighResolution);

        //    data.PropertiesToUseForChart.Add("XValue");
        //    data.PropertiesToUseForChart.Add("YValue1");
        //    data.PropertiesToUseForChart.Add("YValue2");
        //    data.PropertiesToUseForChart.Add("YValue3");

        //    data.LabelsForSeries.Add("Aktien");
        //    data.LabelsForSeries.Add("Renten");
        //    data.LabelsForSeries.Add("Liquidität");

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);
        //}


        //[Test]
        //public void TestStackedBarChart()
        //{

        //    var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_StackedBarChart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {

        //        Title = "Test portfolio",
        //        Copyright = "Testfirma",
        //        XLabelText = "Anlageklassen",
        //        YLabelText = "Anteil in %",
        //        DataSource = TestDataHelper.ChartSample(),

        //        FileName = fileName,
        //        ChartType = ChartType.StackedBarChart,

        //    };

        //    TestHelper.LoadDefaultChartStyle(data, HighResolution);

        //    data.PropertiesToUseForChart.Add("XValue");
        //    data.PropertiesToUseForChart.Add("YValue1");
        //    data.PropertiesToUseForChart.Add("YValue2");
        //    data.PropertiesToUseForChart.Add("YValue3");

        //    data.LabelsForSeries.Add("Aktien");
        //    data.LabelsForSeries.Add("Renten");
        //    data.LabelsForSeries.Add("Liquidität");

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);
        //}



        //[Test]
        //public void TestStackedColumn100Chart()
        //{

        //    var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_StackedColumn100Chart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {


        //        Title = "Test portfolio",
        //        Copyright = "Testfirma",
        //        XLabelText = "Anlageklassen",
        //        YLabelText = "Anteil in %",
        //        DataSource = TestDataHelper.ChartSample(),

        //        FileName = fileName,
        //        ChartType = ChartType.StackedColumn100Chart,

        //    };

        //    TestHelper.LoadDefaultChartStyle(data, HighResolution);

        //    data.PropertiesToUseForChart.Add("XValue");
        //    data.PropertiesToUseForChart.Add("YValue1");
        //    data.PropertiesToUseForChart.Add("YValue2");
        //    data.PropertiesToUseForChart.Add("YValue3");

        //    data.LabelsForSeries.Add("Aktien");
        //    data.LabelsForSeries.Add("Renten");
        //    data.LabelsForSeries.Add("Liquidität");

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);
        //}


        //[Test]
        //public void TestStockChart()
        //{

        //    var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_StockChart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {

        //        Title = "Return",
        //        Copyright = "Testfirma",
        //        XLabelText = "Periods",
        //        YLabelText = "Return in %",

        //        DataSource = TestDataHelper.ChartSampleStockChart(),

        //        FileName = fileName,
        //        ChartType = ChartType.StockChart,
        //        //YAxisNumberformat = "0"
        //    };

        //    TestHelper.LoadDefaultChartStyle(data, HighResolution);

        //    data.PropertiesToUseForChart.Add("XValue");
        //    data.PropertiesToUseForChart.Add("YValue1");
        //    data.PropertiesToUseForChart.Add("YValue2");
        //    data.PropertiesToUseForChart.Add("YValue3");

        //    //data.LabelsForSeries.Add("Aktien");
        //    //data.LabelsForSeries.Add("Renten");
        //    //data.LabelsForSeries.Add("Liquidität");

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);

        //}

    }
}