// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using System.Drawing;
using System.Runtime.Versioning;
using Bodoconsult.Core.Charting.Base.Models;
using ScottPlot;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Creates a pie chart
    /// </summary>
    /// <typeparam name="T">input data type</typeparam>
    [SupportedOSPlatform("windows")]
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

            var pie = Chart.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowPercentages = true;
            pie.ShowLabels = false;

            //var x = pie.donutSize;
            //Chart.Legend(enableLegend: true, style.FontName, style.FontSize, fontColor: style.FontColor, 
            //    frameColor: Color.Transparent, location: legendLocation.lowerRight, backColor: Color.Transparent);

            var legend = Chart.Legend();
            legend.IsVisible = true;
            legend.Location = Alignment.LowerRight;
            legend.FillColor = Color.Transparent;
            legend.OutlineColor = Color.Transparent;
            legend.FontSize = style.FontSize;
            legend.FontColor = style.FontColor;
            legend.FontBold = false;
            legend.FontName = style.FontName;


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
            Chart.Frameless();
            Chart.XAxis.Ticks(false);
            Chart.YAxis.Ticks(false);
        }
    }
}
