using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Charting.Test
{
    [TestFixture]
    public class UnitTestChartHandler_NoDatabase_HighRes : BaseTestChartHandler
    {

        public UnitTestChartHandler_NoDatabase_HighRes()
        {
            HighResolution = true;
            UseDatabase = false;
        }

        [SetUp]
        public void Setup()
        {
            HighResolution = true;
            UseDatabase = false;
        }

        //    [Test]
        //    public void TestPieChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_PieChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781
        //            },

        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.PieChartSample(),

        //            FileName = fileName,
        //            ChartType = ChartType.PieChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };



        //        x.Export();

        //        TestHelper.StartFile(fileName);
        //    }


        //    [Test]
        //    public void TestPointChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_PointChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {

        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Risiko in %",
        //            YLabelText = "Rendite in %",
        //            DataSource = TestDataHelper.PointChartSample(),

        //            FileName = fileName,
        //            ChartType = ChartType.PointChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        Assert.IsTrue(File.Exists(fileName));

        //    }

        //    [Test]
        //    public void TestBarChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_BarChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {

        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.BarChartSample(),

        //            FileName = fileName,
        //            ChartType = ChartType.BarChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };

        //        x.Export();


        //        Assert.IsTrue(File.Exists(fileName));

        //    }


        //    [Test]
        //    public void TestColumnChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_ColumnChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.BarChartSample(),
        //            FileName = fileName,
        //            ChartType = ChartType.ColumnChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();


        //        Assert.IsTrue(File.Exists(fileName));

        //    }

        //    [Test]
        //    public void TestLineChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_LineChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781,

        //            },

        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.ChartSample(),
        //            FileName = fileName,
        //            ChartType = ChartType.LineChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.ChartStyle.XAxisNumberformat = "dd.MM.yyyy";

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        data.LabelsForSeries.Add("Aktien");
        //        data.LabelsForSeries.Add("Renten");
        //        data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();


        //        TestHelper.StartFile(fileName);
        //    }



        //    [Test]
        //    public void TestLineChart_SmallValues()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_LineChart_SmallValues_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781
        //            },

        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.ChartSampleSmallValues(),
        //            FileName = fileName,
        //            ChartType = ChartType.LineChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        data.LabelsForSeries.Add("Aktien");
        //        data.LabelsForSeries.Add("Renten");
        //        data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        Assert.IsTrue(File.Exists(fileName));

        //    }


        //    [Test]
        //    public void TestLineChart_Histogram()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_LineChart_Histogram_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {

        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781
        //            },

        //            Title = "Histogram",
        //            Copyright = "Testfirma",
        //            XLabelText = "Klasse",
        //            YLabelText = "Anzahl",
        //            DataSource = TestDataHelper.ChartSampleHistogram(),

        //            FileName = fileName,
        //            ChartType = ChartType.LineChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");

        //        //data.LabelsForSeries.Add("Kumulierter Anteil");


        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        Assert.IsTrue(File.Exists(fileName));

        //    }


        //    [Test]
        //    public void TestLineChart_Percentages()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_LineChart_Percentages_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781,
        //                YAxisNumberformat = "0.0000%"
        //            },
        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.ChartSampleSmallValues(),

        //            FileName = fileName,
        //            ChartType = ChartType.LineChart

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        data.LabelsForSeries.Add("Aktien");
        //        data.LabelsForSeries.Add("Renten");
        //        data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        TestHelper.StartFile(fileName);
        //    }


        //    //[Test]
        //    //public void TestLineChart_XAxisDouble()
        //    //{

        //    //    const string fileName = @"d:\temp\ScottPlott_LineChart_highres.png";

        //    //    if (File.Exists(fileName)) File.Delete(fileName);

        //    //    var data = new ChartData<ChartItemData1>
        //    //    {
        //    //        Width = 750,
        //    //        Height = 550,
        //    //        Title = "Test portfolio",
        //    //        DataSource = TestData.ChartSampleDouble(),
        //    //        Copyright = "Testfirma",
        //    //        XLabelText = "Anlageklassen",
        //    //        YLabelText = "Anteil in %",
        //    //        FileName = fileName,
        //    //        ChartType = ChartType.LineChart,

        //    //    };

        //    //    data.PropertiesToUseForChart.Add("XValue");
        //    //    data.PropertiesToUseForChart.Add("YValue1");
        //    //    data.PropertiesToUseForChart.Add("YValue2");
        //    //    data.PropertiesToUseForChart.Add("YValue3");

        //    //    data.LabelsForSeries.Add("Aktien");
        //    //    data.LabelsForSeries.Add("Renten");
        //    //    data.LabelsForSeries.Add("Liquidität");

        //    //    var x = new ChartHandler<ChartItemData1>
        //    //    {
        //    //        ChartData = data
        //    //    };

        //    //    x.Export();

        //    //    Assert.IsTrue(File.Exists(fileName));

        //    //}



        //    [Test]
        //    public void TestStackedColumnChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_StackedColumnChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781
        //            },
        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.ChartSample(),

        //            FileName = fileName,
        //            ChartType = ChartType.StackedColumnChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        data.LabelsForSeries.Add("Aktien");
        //        data.LabelsForSeries.Add("Renten");
        //        data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        TestHelper.StartFile(fileName);
        //    }


        //    [Test]
        //    public void TestStackedBarChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_StackedBarChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781
        //            },
        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.ChartSample(),
        //            FileName = fileName,
        //            ChartType = ChartType.StackedBarChart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        data.LabelsForSeries.Add("Aktien");
        //        data.LabelsForSeries.Add("Renten");
        //        data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        TestHelper.StartFile(fileName);
        //    }



        //    [Test]
        //    public void TestStackedColumn100Chart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_StackedColumn100Chart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                YAxisNumberformat = "0.0000%",
        //                Width = 4500,
        //                Height = 2781
        //            },
        //            Title = "Test portfolio",
        //            Copyright = "Testfirma",
        //            XLabelText = "Anlageklassen",
        //            YLabelText = "Anteil in %",
        //            DataSource = TestDataHelper.ChartSample(),
        //            FileName = fileName,
        //            ChartType = ChartType.StackedColumn100Chart,

        //        };

        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        data.LabelsForSeries.Add("Aktien");
        //        data.LabelsForSeries.Add("Renten");
        //        data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        TestHelper.StartFile(fileName);
        //    }


        //    [Test]
        //    public void TestStockChart()
        //    {

        //        const string fileName = @"d:\temp\ScottPlott_StockChart_highres.png";

        //        if (File.Exists(fileName)) File.Delete(fileName);

        //        var data = new ChartData
        //        {
        //            ChartStyle =
        //            {
        //                Width = 4500,
        //                Height = 2781
        //            },
        //            Title = "Return",
        //            Copyright = "Testfirma",
        //            XLabelText = "Periods",
        //            YLabelText = "Return in %",
        //            DataSource = TestDataHelper.ChartSampleStockChart(),

        //            FileName = fileName,
        //            ChartType = ChartType.StockChart,
        //            //YAxisNumberformat = "0"
        //        };
        //        TestHelper.LoadDefaultChartStyle(data);

        //        data.PropertiesToUseForChart.Add("XValue");
        //        data.PropertiesToUseForChart.Add("YValue1");
        //        data.PropertiesToUseForChart.Add("YValue2");
        //        data.PropertiesToUseForChart.Add("YValue3");

        //        //data.LabelsForSeries.Add("Aktien");
        //        //data.LabelsForSeries.Add("Renten");
        //        //data.LabelsForSeries.Add("Liquidität");

        //        var x = new ChartHandler
        //        {
        //            ChartData = data
        //        };


        //        x.Export();

        //        TestHelper.StartFile(fileName);
        //    }

        //}
    }
}