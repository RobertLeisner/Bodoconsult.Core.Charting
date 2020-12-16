﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Charting.Util;
using ScottPlot;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Creates a point chart
    /// </summary>
    /// <typeparam name="T">data input type</typeparam>
    public class PointChart<T> : BaseChart<T> where T : IChartItemData
    {
        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            var style = ChartData.ChartStyle;

            var formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
            var formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;

            var markerSize = 15;

            var data = new List<PointChartItemData>(ChartData.DataSource.Count);

            for (var index = 0; index < ChartData.DataSource.Count; index++)
            {
                data.Add((PointChartItemData)ChartData.DataSource[index]);
            }

            var maxX = data.Max(x => x.XValue);
            var maxY = data.Max(x => x.YValue);
            var minX = data.Min(x => x.XValue);
            var minY = data.Min(x => x.YValue);

            var deltaX = (maxX - minX) / 35;
            var deltaY = (maxY - minY) / 30;

            if (formatX.Contains("P") || formatX.Contains("%"))
            {
                maxX = Math.Ceiling(maxX / 10) * 10 / 100;
                maxY = Math.Ceiling(maxY / 10) * 10;
            }
            else
            {
                maxX = Math.Ceiling(maxX / 10) * 10;
                maxY = Math.Ceiling(maxY / 10) * 10;
            }


            if (formatY.Contains("P") || formatY.Contains("%"))
            {
                maxY = (Math.Ceiling(maxY / 10)) * 10 / 100;
            }
            else
            {
                maxY = (Math.Ceiling(maxY / 10) ) * 10;
            }


            Chart.PlotPoint(deltaX / 100, deltaY / 100, color: Color.Transparent, markerSize: 0);
            Chart.PlotPoint(maxX, maxY, color: Color.Transparent, markerSize: 0);

            for (var index = 0; index < data.Count; index++)
            {
                var item = data[index];

                Chart.PlotPoint(item.XValue, item.YValue, label: item.Label, color: item.Color, markerSize: markerSize);

                Chart.PlotText(item.Label, item.XValue + deltaX, item.YValue, color: item.Color, fontName: style.FontName,
                    fontSize: style.FontSize);

            }

            // Titels for axis
            var label = string.IsNullOrEmpty(ChartData.XLabelText)
                ? ChartData.PropertiesToUseForChart[0]
                : ChartData.XLabelText;

            Chart.XLabel(label, fontName: style.FontName, fontSize: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            label = string.IsNullOrEmpty(ChartData.YLabelText)
                ? ChartData.PropertiesToUseForChart[1]
                : ChartData.YLabelText;

            Chart.YLabel(label, fontName: style.FontName, fontSize: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);


            Chart.Ticks(dateTimeX: false, numericFormatStringX: formatX, numericFormatStringY: formatY);


            base.CreateChart();
        }


        /// <summary>
        /// Formatting the chart
        /// </summary>
        public override void Formatting()
        {
            base.Formatting();

            var style = ChartData.ChartStyle;

            Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor);

            //Chart.Legend(enableLegend: true, location: legendLocation.lowerRight, backColor: Color.WhiteSmoke, frameColor: Color.Transparent,
            //    fontSize: style.FontSize * style.LegendFontSizeDelta, bold: false, fontColor: style.FontColor);
        }

        ///// <summary>
        ///// Base formatting for the chart
        ///// </summary>
        //public override void Formatting()
        //{

        //    //var s = Chart.Series[0];
        //    //s.BorderWidth = ChartData.ChartStyle.SeriesLineWidth;
        //    //s.Font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize);

        //    //s.ChartType = SeriesChartType.Point;
        //    //s.MarkerStyle = MarkerStyle.Circle;
        //    //s.MarkerSize = s.Points.Count>10 ? 15 : 25;


        //    //var c = Chart.ChartAreas["Default"];
        //    //c.Area3DStyle.Enable3D = false;
        //    //c.Area3DStyle.Rotation = 0;
        //    //c.BackColor = Color.Transparent;
        //    //c.AlignmentStyle = AreaAlignmentStyles.All;
        //    //c.Position = new ElementPosition(5, 12, 83, 80);

        //    //c.AxisX.MajorGrid.Enabled = true;
        //    //c.AxisX.MajorGrid.LineColor = Color.LightGray;
        //    //c.AxisX.Title = ChartData.XLabelText;

        //    //c.AxisY.MajorGrid.Enabled = true;
        //    //c.AxisY.MajorGrid.LineColor = Color.LightGray;
        //    //c.AxisY.Title = ChartData.YLabelText;

        //    //c.BorderColor = Color.Black;
        //    //c.BorderWidth = ChartData.ChartStyle.BorderLineWidth;
        //    //c.BorderDashStyle = ChartDashStyle.Solid;

        //    base.Formatting();
        //}
    }
}
