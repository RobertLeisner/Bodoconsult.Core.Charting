using System.IO;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Test.Helpers;
using Bodoconsult.Core.Charting.Util;
using NUnit.Framework;

namespace Bodoconsult.Core.Charting.Test
{
    public abstract class BaseTestChartHandler
    {

        protected bool HighResolution;

        protected bool UseDatabase;


        [Test]
        public void TestStackedBarChart()
        {

            // const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";

            const string fileName = @"d:\temp\ScottPlott_Db_StackedBarChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_Db_StackedColumnChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_Db_StackedColumn100Chart.png";

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

            const string fileName = @"d:\temp\ScottPlott_PieChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_PointChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_PointChart_Percent.png";

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

            const string fileName = @"d:\temp\ScottPlott_BarChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_ColumnChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_LineChart.png";

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

            const string fileName = @"d:\temp\ScottPlott_LineChart_SmallValues.png";

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

            const string fileName = @"d:\temp\ScottPlott_LineChart_Histogram.png";

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

            const string fileName = @"d:\temp\ScottPlott_LineChart_Percentages.png";

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

        //    const string fileName = @"d:\temp\ScottPlott_LineChart.png";

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

        //    const string fileName = @"d:\temp\ScottPlott_StackedColumnChart.png";

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

        //    const string fileName = @"d:\temp\ScottPlott_StackedBarChart.png";

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

        //    const string fileName = @"d:\temp\ScottPlott_StackedColumn100Chart.png";

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

        //    const string fileName = @"d:\temp\ScottPlott_StockChart.png";

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