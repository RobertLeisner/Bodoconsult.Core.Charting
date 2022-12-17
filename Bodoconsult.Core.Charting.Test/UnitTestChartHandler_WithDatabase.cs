// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.IO;
using System.Runtime.Versioning;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Test.Helpers;
using Bodoconsult.Core.Charting.Util;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Charting.Test
{
    [TestFixture]
    [SupportedOSPlatform("windows")]
    public class UnitTestChartHandler_WithDatabase: BaseTestChartHandler
    {

        public UnitTestChartHandler_WithDatabase()
        {
            HighResolution = false;
            UseDatabase = true;
        }


        [Test]
        public void TestRealLife_Chart3()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart3.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.LineChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart3.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

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
        public void TestRealLife_Chart22()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart22.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.LineChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart22.xml");
            ChartUtility.DataTableToChartItemData(dt, "1;5;6;7", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestRealLife_Chart20003()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart20003.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.LineChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart20003.xml");
            ChartUtility.DataTableToChartItemData(dt, "1;2", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }

        [Test]
        public void TestRealLife_Chart60012()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart60012.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                //XLabelText = "Anlageklassen",
                //YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.PointChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart60012.xml");
            ChartUtility.DataTableToPointChartItemData(dt, "1;2;3;4", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }



        [Test]
        public void TestRealLife_Chart60001()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart60001.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.LineChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart60001.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }




        [Test]
        public void TestRealLife_Chart60002()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart60012.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                //XLabelText = "Anlageklassen",
                //YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.StackedColumnChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart60002.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        [Test]
        public void TestRealLife_Chart60002_Barchart()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart60012.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                //XLabelText = "Anlageklassen",
                //YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.StackedBarChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart60002.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }

        [Test]
        public void TestRealLife_Chart60002_Column100()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart60012.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                //XLabelText = "Anlageklassen",
                //YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.StackedColumn100Chart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart60002.xml");
            ChartUtility.DataTableToChartItemData(dt, "", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }

        [Test]
        public void TestRealLife_Chart40001()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart40001.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.PieChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart40001.xml");
            ChartUtility.DataTableToPieChartItemData(dt, "1;2", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        //[Test]
        //public void TestRealLife_Chart60012()
        //{

        //    const string fileName = @"d:\temp\ScottPlott_Chart3.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {
        //        Title = "Test portfolio",
        //        Copyright = "Testfirma",
        //        XLabelText = "Anlageklassen",
        //        YLabelText = "Anteil in %",
        //        FileName = fileName,
        //        ChartType = ChartType.PointChart,
        //        //PaperColor = Color.Red
        //    };

        //    TestHelper.LoadDefaultChartStyle(data, HighResolution);

        //    var dt = TestHelper.GetDataTable("chart60012.xml");
        //    ChartUtility.DataTableToPointChartItemData(dt, "1;2;(3);(4)", data);

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);
        //}

        [Test]
        public void TestRealLife_Chart190003()
        {

            const string fileName = @"d:\temp\ScottPlott_Chart3.png";

            if (File.Exists(fileName)) File.Delete(fileName);

            var data = new ChartData
            {
                Title = "Test portfolio",
                Copyright = "Testfirma",
                XLabelText = "Anlageklassen",
                YLabelText = "Anteil in %",
                FileName = fileName,
                ChartType = ChartType.ColumnChart,
                //PaperColor = Color.Red
            };

            TestHelper.LoadDefaultChartStyle(data, HighResolution);

            var dt = TestHelper.GetDataTable("chart190003.xml");
            ChartUtility.DataTableToChartItemData(dt, "1;5;6", data);

            var x = new ChartHandler
            {
                ChartData = data
            };

            x.Export();

            TestHelper.StartFile(fileName);
        }


        //[Test]
        //public void TestPieChart()
        //{

        //    const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate'  exec Vermoegen_Db.dbo.GetRegionenStruktur 1";

        //    const string fileName = @"d:\temp\ScottPlott_Db_PieChart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {
        //        ChartStyle =
        //        {
        //            Width = 750,
        //            Height = 550,

        //        },

        //        Title = "Test portfolio",
        //        Copyright = "Testfirma",
        //        YLabelText = "Anteil in %",
        //        FileName = fileName,
        //        ChartType = ChartType.PieChart,

        //    };

        //    TestHelper.LoadDefaultChartStyle(data);

        //    var dt = TestHelper.GetDataTable("PieChart.xml");
        //    ChartUtility.DataTableToPieChartItemData(dt, "1;2", data);

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);
        //}


        //        [Test]
        //        public void TestPointChart()
        //        {
        //            const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate'  exec Vermoegen_Db.dbo.GetRiskReturnAssets 1";

        //            const string fileName = @"d:\temp\ScottPlott_Db_PointChart.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },

        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Risiko in %",
        //                YLabelText = "Rendite in %",
        //                FileName = fileName,
        //                ChartType = ChartType.PointChart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("PointChart.xml");
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler<PointChartItemData>
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }


        //        [Test]
        //        public void TestPointChart_Performance()
        //        {
        //            const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.dbo.GetPerformanceYearly 2";

        //            const string fileName = @"d:\temp\ScottPlott_Db_PointChart_Performance.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },

        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Risiko in %",
        //                YLabelText = "Rendite in %",
        //                FileName = fileName,
        //                ChartType = ChartType.PointChart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("PointChart_Performance.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }

        //        /// <summary>
        //        /// 
        //        /// </summary>


        //        [Test]
        //        public void TestBarChart()
        //        {
        //            const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate'  exec Vermoegen_Db.dbo.GetRegionenStruktur 1";

        //            const string fileName = @"d:\temp\ScottPlott_Db_BarChart.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                FileName = fileName,
        //                ChartType = ChartType.BarChart,
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },
        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteil in %"
        //            };


        //              TestHelper.LoadDefaultChartStyle(data);


        //            var dt = GetDataTable("BarChart.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }






        //        [Test]
        //        public void TestColumnChart()
        //        {

        //            const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate'  exec Vermoegen_Db.dbo.GetRegionenStruktur 1";


        //            const string fileName = @"d:\temp\ScottPlott_Db_ColumnChart.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },
        //                FileName = fileName,
        //                ChartType = ChartType.ColumnChart,
        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteil in %",

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("ColumnChart.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }

        //[Test]
        //public void TestLineChart()
        //{

        //    const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";

        //    const string fileName = @"d:\temp\ScottPlott_Db_LineChart.png";

        //    if (File.Exists(fileName)) File.Delete(fileName);

        //    var data = new ChartData
        //    {
        //        ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },
        //        Title = "Test portfolio",
        //        Copyright = "Testfirma",
        //        XLabelText = "Anlageklassen",
        //        YLabelText = "Anteilswert",
        //        FileName = fileName,
        //        ChartType = ChartType.LineChart,

        //    };

        //    TestHelper.LoadDefaultChartStyle(data);

        //    var dt = TestHelper.GetDataTable("LineChart.xml");
        //    ChartUtility.DataTableToChartItemDataDouble(dt, "", data);

        //    var x = new ChartHandler
        //    {
        //        ChartData = data
        //    };

        //    x.Export();

        //    TestHelper.StartFile(fileName);
        //}


        //        [Test]
        //        public void TestLineChartNoData()
        //        {

        //            const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'BODOCONSULT\bodobeteiligungen' EXEC Vermoegen_Db.dbo.GetDividendenHistorie 1";

        //            const string fileName = @"d:\temp\ScottPlott_Db_LineChart_NoData.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },
        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteilswert",
        //                FileName = fileName,
        //                ChartType = ChartType.LineChart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("LineChartNoData.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }


        //        [Test]
        //        public void TestLineChart_Test()
        //        {

        //            const string sql = "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate'  exec Vermoegen_Db.dbo.GetPerformanceYearly";

        //            const string fileName = @"d:\temp\ScottPlott_Db_LineChart_Test.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },
        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteilswert",
        //                FileName = fileName,
        //                ChartType = ChartType.LineChart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("LineChart_Test.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }


        //        [Test]
        //        public void TestStackedColumnChart()
        //        {

        //            const string sql =
        //                "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";

        //            const string fileName = @"d:\temp\ScottPlott_Db_StackedColumnChart.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },

        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteilswert",
        //                FileName = fileName,
        //                ChartType = ChartType.StackedColumnChart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("StackedColumnNoData.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }


        //        [Test]
        //        public void TestStackedBarChart()
        //        {

        //            const string sql =
        //                "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate' exec Vermoegen_Db.[dbo].[GetAnteilswerte] 120, 1";

        //            const string fileName = @"d:\temp\ScottPlott_Db_StackedBarChart.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {
        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },

        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteilswert",
        //                FileName = fileName,
        //                ChartType = ChartType.StackedBarChart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("StackedBarChart.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data); 

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }



        //        [Test]
        //        public void TestStackedColumn100Chart()
        //        {
        //            const string sql =
        //                "EXEC Vermoegen_Db.[dbo].SetFinDBUser 'bodoprivate'  exec Vermoegen_Db.dbo.GetAktuellesVermögenStruktur";

        //            const string fileName = @"d:\temp\ScottPlott_Db_StackedColumn100Chart.png";

        //            if (File.Exists(fileName)) File.Delete(fileName);

        //            var data = new ChartData
        //            {

        //                ChartStyle =
        //                {
        //                    Width = 750,
        //                    Height = 550,

        //                },

        //                Title = "Test portfolio",
        //                Copyright = "Testfirma",
        //                XLabelText = "Anlageklassen",
        //                YLabelText = "Anteil in %",
        //                FileName = fileName,
        //                ChartType = ChartType.StackedColumn100Chart,

        //            };

        //              TestHelper.LoadDefaultChartStyle(data);

        //            var dt = GetDataTable("StackedColumnChart.xml", sql);
        //            ChartUtility.DataTableToChartData(dt, "", data);

        //            var x = new ChartHandler
        //            {
        //                ChartData = data
        //            };

        //            x.Export();

        //            TestHelper.StartFile(fileName);
        //        }



    }
}