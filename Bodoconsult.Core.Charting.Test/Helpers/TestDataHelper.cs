using System;
using System.Drawing;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Util;

namespace Bodoconsult.Core.Charting.Test.Helpers
{
    internal static class TestDataHelper
    {
        /// <summary>
        /// Get data for a sample pie chart
        /// </summary>
        /// <returns></returns>
        public static void PieChartSample(bool useDatabase, ChartData data)
        {

            var erg = data.DataSource;


            if (useDatabase)
            {
                var dt = TestHelper.GetDataTable("PieChart.xml");
                ChartUtility.DataTableToPieChartItemData(dt, "1;2", data);
            }
            else
            {
                // shares
                var item = new PieChartItemData
                {
                    XValue = "Aktien",
                    YValue = 0.5
                };

                erg.Add(item);

                // fixed income
                item = new PieChartItemData
                {
                    XValue = "Anleihen",
                    YValue = 0.4
                };

                erg.Add(item);

                // liquidity
                item = new PieChartItemData
                {
                    XValue = "Liquidität",
                    YValue = 0.1
                };

                erg.Add(item);

                data.PropertiesToUseForChart.Add("XValue");
                data.PropertiesToUseForChart.Add("YValue");
            }
        }


        /// <summary>
        /// Get data for a sample point chart
        /// </summary>
        /// <param name="useDatabase"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static void PointChartSample(bool useDatabase, ChartData data)
        {

            var erg = data.DataSource;

            if (useDatabase)
            {
                var dt = TestHelper.GetDataTable("PointChart.xml");
                ChartUtility.DataTableToPointChartItemData(dt, "", data);
            }
            else
            {
                // shares
                var item = new PointChartItemData
                {
                    XValue = 10,
                    YValue = 8,
                    Label = "Aktien",
                    Color = Color.Red
                };

                erg.Add(item);

                // fixed income
                item = new PointChartItemData
                {
                    XValue = 5,
                    YValue = 4,
                    Label = "Anleihen",
                    Color = Color.Gray
                };

                erg.Add(item);

                // liquidity
                item = new PointChartItemData
                {
                    XValue = 2,
                    YValue = 1,
                    Label = "Liquidität",
                    Color = Color.LightGray
                };



                erg.Add(item);

                data.PropertiesToUseForChart.Add("Risk");
                data.PropertiesToUseForChart.Add("Return");

            }



        }


        /// <summary>
        /// Get data for a sample point chart
        /// </summary>
        /// <param name="useDatabase"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static void PointChartSamplePercent(bool useDatabase, ChartData data)
        {

            var erg = data.DataSource;

            // shares
            var item = new PointChartItemData
            {
                XValue = 0.10,
                YValue = 0.08,
                Label = "Aktien",
                Color = Color.Red
            };

            erg.Add(item);

            // fixed income
            item = new PointChartItemData
            {
                XValue = 0.05,
                YValue = 0.04,
                Label = "Anleihen",
                Color = Color.Gray
            };

            erg.Add(item);

            // liquidity
            item = new PointChartItemData
            {
                XValue = 0.02,
                YValue = 0.01,
                Label = "Liquidität",
                Color = Color.LightGray
            };

            erg.Add(item);
        }


        /// <summary>
        /// Get data for a samplebar chart
        /// </summary>
        /// <param name="useDatabase"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void BarChartSample(bool useDatabase, ChartData data)
        {

            var erg = data.DataSource;

            if (useDatabase)
            {
                var dt = TestHelper.GetDataTable("BarChart.xml");
                ChartUtility.DataTableToChartItemData(dt, "1;3", data);
            }
            else
            {
                // shares
                var item = new ChartItemData
                {
                    Label= "Aktien",
                    YValue1 = 0.5
                };

                erg.Add(item);

                // fixed income
                item = new ChartItemData
                {
                    Label = "Anleihen",
                    YValue1 = 0.4
                };

                erg.Add(item);

                // liquidity
                item = new ChartItemData
                {
                    YValue1 = 0.1,
                   Label = "Liquidität",
                };

                erg.Add(item);

                data.PropertiesToUseForChart.Add("XValue");
                data.PropertiesToUseForChart.Add("YValue");
            }

        }


        public static void ChartSample(bool useDatabase, ChartData data)
        {

            var erg = data.DataSource;


            if (useDatabase)
            {
                var dt = TestHelper.GetDataTable("LineChart.xml");
                ChartUtility.DataTableToChartItemData(dt, "", data);
            }
            else
            {

                var date = DateTime.Now;

                // 
                var item = new ChartItemData
                {
                    XValue = date.AddMonths(-2).ToOADate(),
                    YValue1 = 276137,
                    YValue2 = 71735,
                    YValue3 = 69805,
                    IsDate = true,
                };

                erg.Add(item);

                // 
                item = new ChartItemData
                {
                    XValue = date.AddMonths(-1).ToOADate(),
                    YValue1 = 76137,
                    YValue2 = 171735,
                    YValue3 = 269805,
                    IsDate = true,
                };

                erg.Add(item);

                // 
                item = new ChartItemData
                {
                    XValue = date.ToOADate(),
                    YValue1 = 276137,
                    YValue2 = 71735,
                    YValue3 = 69805,
                    IsDate = true,
                };

                erg.Add(item);

                data.PropertiesToUseForChart.Add("XValue");
                data.PropertiesToUseForChart.Add("YValue1");
                data.PropertiesToUseForChart.Add("YValue2");
                data.PropertiesToUseForChart.Add("YValue3");

                data.LabelsForSeries.Add("Aktien");
                data.LabelsForSeries.Add("Renten");
                data.LabelsForSeries.Add("Liquidität");
            }

            data.ChartStyle.XAxisNumberformat = "dd.MM.yyyy";


        }



        //public static IList<IChartItemData> ChartSampleStockChart()
        //{

        //    var erg = new List<IChartItemData>();

        //    // 
        //    var item = new ChartItemData
        //    {
        //        XValue = "2000",
        //        YValue1 = 101,
        //        YValue2 = 95,
        //        YValue3 = 99
        //    };

        //    erg.Add(item);

        //    // 
        //    item = new ChartItemData
        //    {
        //        XValue = "2001",
        //        YValue1 = 105,
        //        YValue2 = 97,
        //        YValue3 = 100
        //    };

        //    erg.Add(item);

        //    // 
        //    item = new ChartItemData
        //    {
        //        XValue = "2002",
        //        YValue1 = 103,
        //        YValue2 = 99,
        //        YValue3 = 102
        //    };

        //    erg.Add(item);


        //    item = new ChartItemData
        //    {
        //        XValue = "2003",
        //        YValue1 = 105,
        //        YValue2 = 99,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);


        //    item = new ChartItemData
        //    {
        //        XValue = "2004",
        //        YValue1 = 103,
        //        YValue2 = 100,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);


        //    item = new ChartItemData
        //    {
        //        XValue = "2005",
        //        YValue1 = 106,
        //        YValue2 = 104,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);

        //    item = new ChartItemData
        //    {
        //        XValue = "2006",
        //        YValue1 = 103,
        //        YValue2 = 100,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);

        //    item = new ChartItemData
        //    {
        //        XValue = "2007",
        //        YValue1 = 103,
        //        YValue2 = 100,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);


        //    item = new ChartItemData
        //    {
        //        XValue = "2008",
        //        YValue1 = 103,
        //        YValue2 = 100,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);

        //    item = new ChartItemData
        //    {
        //        XValue = "2009",
        //        YValue1 = 109,
        //        YValue2 = 102,
        //        YValue3 = 103
        //    };

        //    erg.Add(item);

        //    return erg;

        //}


        //public static IList<IChartItemData> ChartSampleDouble()
        //{

        //    var erg = new List<IChartItemData>();

        //    // 
        //    var item = new ChartItemData1
        //    {
        //        XValue = 1.0,
        //        YValue1 = 276137,
        //        YValue2 = 71735,
        //        YValue3 = 69805
        //    };

        //    erg.Add(item);

        //    // 
        //    item = new ChartItemData1
        //    {
        //        XValue = 1.4,
        //        YValue1 = 76137,
        //        YValue2 = 171735,
        //        YValue3 = 269805
        //    };

        //    erg.Add(item);

        //    // 
        //    item = new ChartItemData1
        //    {
        //        XValue = 2.8,
        //        YValue1 = 276137,
        //        YValue2 = 71735,
        //        YValue3 = 69805
        //    };

        //    erg.Add(item);

        //    return erg;

        //}

        internal static void ChartSampleSmallValues(bool useDatabase, ChartData data)
        {
            var erg = data.DataSource;

            // 
            var item = new ChartItemData
            {
                XValue = 0.0006,
                YValue1 = 0.0000076137
            };

            erg.Add(item);

            // 
            item = new ChartItemData
            {
                XValue = 0.0007,
                YValue1 = 0.76137
            };

            erg.Add(item);

            // 
            item = new ChartItemData
            {
                XValue = 0.008,
                YValue1 = 0.276137

            };

            erg.Add(item);

        }

        internal static void ChartSampleHistogram(bool useDatabase, ChartData data)
        {
            var erg = data.DataSource;

            // 
            var item = new ChartItemData
            {
                XValue = -0.0405,
                YValue1 = 0.02
            };

            erg.Add(item);

            // 
            item = new ChartItemData
            {
                XValue = -0.0177,
                YValue1 = 0.09
            };

            erg.Add(item);

            // 
            item = new ChartItemData
            {
                XValue = 0.0051,
                YValue1 = 0.22

            };

            erg.Add(item);

            item = new ChartItemData
            {
                XValue = 0.0279,
                YValue1 = 0.59

            };

            erg.Add(item);


            item = new ChartItemData
            {
                XValue = 0.0507,
                YValue1 = 0.72

            };

            erg.Add(item);


            item = new ChartItemData
            {
                XValue = 0.0735,
                YValue1 = 0.65

            };

            erg.Add(item);


            item = new ChartItemData
            {
                XValue = 0.0963,
                YValue1 = 0.01

            };

            erg.Add(item);

        }


        //         0.02
        // 0.09
        // 0.22
        // 0.35
        // 0.59
        // 0.72
        // 0.86
        //"1,191%" 0.93
        //"1,419%" 0.98
        //"1,646%" 1


    }

}
