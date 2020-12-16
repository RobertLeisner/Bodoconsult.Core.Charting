using System;
using System.Drawing;
using Bodoconsult.Core.Charting.Base.Models;
using ScottPlot;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Creates a pie chart
    /// </summary>
    /// <typeparam name="T">input data type</typeparam>
    public class PieChart<T> : BaseChart<T> where T : PieChartItemData
    {
        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            var style = ChartData.ChartStyle;


            var values = new double[ChartData.DataSource.Count];

            var labels = new string[ChartData.DataSource.Count];

            for (var index = 0; index < ChartData.DataSource.Count; index++)
            {
                var data = (PieChartItemData) ChartData.DataSource[index];

                values[index] = Convert.ToDouble(data.YValue);
                labels[index] = data.XValue;
            }

            //var pie =
            Chart.PlotPie(values, labels, showPercentages: true, showLabels: false);


            //var x = pie.donutSize;
            Chart.Legend(enableLegend: true, style.FontName, style.FontSize, fontColor: style.FontColor, 
                frameColor: Color.Transparent, location: legendLocation.lowerRight, backColor: Color.Transparent);

            //Chart.Grid(false);
            //Chart.Frame(false);
            //Chart.Ticks(false, false);
            //Chart.Layout(yScaleWidth: 80, titleHeight: 50, xLabelHeight: 20, y2LabelWidth: 20);

            base.CreateChart();
        }

        /// <summary>
        /// Base formatting for the chart
        /// </summary>
        public override void Formatting()
        {
            base.Formatting();

            Chart.Grid(false);
            Chart.Frame(false);
            Chart.Ticks(false, false);


        }
    }
}
