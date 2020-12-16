using System.Collections.Generic;
using System.Drawing;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Util;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Creates a stock chart
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StockChart<T> : BaseChart<T> where T: IChartItemData
    {

        //private bool _isContinousXAxis;

        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            //if (typeof(T)== typeof(ChartItemData1))
            //{
            //    _isContinousXAxis = true;
            //}

            AdjustLabels();

            //var data = (List<ChartItemData>) ChartData.DataSource;

            //var s = Chart.Series.Add("Price");
            //s.ChartType = SeriesChartType.Stock;

            //// Set the style of the open-close marks
            //s["OpenCloseStyle"] = "Line";

            //// Show both open and close marks
            //s["ShowOpenClose"] = "Open";
            //s["PointWidth"] = "0.5";
            ////s["PixelPointWidth"] = "20";
            //s.Color = Color.Red;
 


            //var index = s.Points.AddXY(" ", data[0].YValue1);
            //s.Points[index].IsVisibleInLegend = false;
            //s.Points[index].BorderWidth = 0;

            //foreach (var row in data)
            //{
            //    index = s.Points.AddXY(row.XValue, row.YValue1);

            //    var point = s.Points[index];
                
            //    point.YValues[1] = row.YValue2;
            //    point.YValues[2] = row.YValue3;
            //    point.YValues[3] = row.YValue1;

            //    point.BorderWidth = (int)(ChartData.ChartStyle.SeriesLineWidth * 3.0);

            //    //point.MarkerSize = 3;
            //    //point.MarkerStyle = MarkerStyle.Circle;
            //}

            //index = s.Points.AddXY(" ", 0);
            //s.Points[index].IsVisibleInLegend = false;
            //s.Points[index].BorderWidth = 0;

            //Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


            //if (data.Count<15) Chart.ChartAreas[0].AxisX.Interval = 1;


            //var min = double.PositiveInfinity;
            //var max = double.NegativeInfinity;


            //foreach (var row in data)
            //{
            //    var value = row.YValue1;

            //    if (value > max) max = value;
            //    if (value < min) min = value;

            //    value = row.YValue2;

            //    if (value > max) max = value;
            //    if (value < min) min = value;

            //    value = row.YValue3;

            //    if (value > max) max = value;
            //    if (value < min) min = value;
            //}


            //var lmin = ChartUtility.GetMinMaxForLineChart(ref min, ref max);


            //if (max > 0)
            //{
            //    var c = Chart.ChartAreas["Default"];
            //    c.AxisY.Maximum = max;
            //    c.AxisY.Minimum = min;
            //    c.AxisY.MajorGrid.Interval = lmin;
            //    c.AxisY.Interval = c.AxisY.MajorGrid.Interval;

            //    if (!string.IsNullOrEmpty(ChartData.ChartStyle.YAxisNumberformat)) c.AxisY.LabelStyle.Format = ChartData.ChartStyle.YAxisNumberformat;

            //    //c.AxisY.MinorGrid.Interval = lmin / 2;
            //    //c.AxisY.MinorGrid.Enabled = true;
            //}


            ////// Legend
            ////var legend = new Legend("Default");
            ////Chart.Legends.Add(legend);

            //// Y-Achse


            base.CreateChart();


        }

        /// <summary>
        /// Formatting the chart
        /// </summary>
        public override void Formatting()
        {
            //var c = Chart.ChartAreas["Default"];
            //c.Area3DStyle.Enable3D = false;
            //c.Area3DStyle.Rotation = 0;
            //c.AlignmentStyle = AreaAlignmentStyles.All;
            //c.AxisX.IsMarginVisible = false;
            //c.AxisX.Title = ChartData.XLabelText;
            //c.AxisX.IsLabelAutoFit = true;
            //c.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont |
            //                            LabelAutoFitStyles.IncreaseFont |
            //                            LabelAutoFitStyles.WordWrap;
            //c.Position = StockChartPositionChartArea();
            //c.AxisY.Title = ChartData.YLabelText;
            //c.BorderColor = Color.Black;
            //c.BorderWidth = ChartData.ChartStyle.BorderLineWidth;
            //c.BorderDashStyle = ChartDashStyle.Solid;

            ////var legend = Chart.Legends["Default"];
            ////legend.LegendStyle = LegendStyle.Row;
            ////legend.Enabled = true;
            ////legend.BackColor = Color.Transparent;
            ////legend.Position = DefaultLegendPosition();
            ////legend.ForeColor = ChartData.FontColor;


            base.Formatting();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private static ElementPosition StockChartPositionChartArea()
        //{
        //    return new ElementPosition(5, 12, 85, 83);
        //}
    }
}